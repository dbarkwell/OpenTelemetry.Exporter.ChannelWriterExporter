using System;
using System.Diagnostics;
using System.Threading.Channels;
using OpenTelemetry.Trace;

namespace OpenTelemetry.Exporter.ChannelWriterExporter
{
    public static class ChannelWriterExporterHelperExtensions
    {
        public static TracerProviderBuilder AddChannelWriterExporter(this TracerProviderBuilder builder, ChannelWriter<Activity> channelWriter)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            
            if (channelWriter == null)
                throw new ArgumentNullException(nameof(channelWriter));
            
            return builder.AddProcessor(new SimpleExportActivityProcessor(new ChannelWriterExporter(channelWriter)));
        }
    }
}