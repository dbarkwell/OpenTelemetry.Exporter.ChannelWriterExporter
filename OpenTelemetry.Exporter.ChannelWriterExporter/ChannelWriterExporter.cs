using System.Diagnostics;
using System.Threading.Channels;
using OpenTelemetry.Trace;

namespace OpenTelemetry.Exporter.ChannelWriterExporter
{
    public class ChannelWriterExporter : ActivityExporter
    {
        private readonly ChannelWriter<Activity> _channelWriter;

        public ChannelWriterExporter(ChannelWriter<Activity> channelWriter)
        {
            _channelWriter = channelWriter;
        }
        
        public override ExportResult Export(in Batch<Activity> batch)
        {
            foreach (var activity in batch)
            {
                if (!_channelWriter.TryWrite(activity))
                    return ExportResult.Failure;
            }

            return ExportResult.Success;
        }
    }
}