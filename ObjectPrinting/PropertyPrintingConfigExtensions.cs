namespace ObjectPrinting
{
    public static class PropertyPrintingConfigExtensions
    {
        public static PrintingConfig<TOwner> TrimmedToLength<TOwner>(this IPropertyPrintingConfig<TOwner, string> pc, int length)
        {
            pc.PrintingConfig.AddTrimmCut(pc.PropertyInfo, length);
            return pc.PrintingConfig;
        }
    }
}