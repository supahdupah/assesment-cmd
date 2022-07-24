namespace Common
{
    //in reality this should not be required as the files are ususally stored externally 
    // if not requires refactor
    public enum SourceType
    {
        Capterra = 0,
        SoftwareAdvice = 1
    }

    public static class FileSelector
    {
        public static string GetFilePath(SourceType sourceType)
        {
            switch (sourceType)
            {
                case SourceType.Capterra:
                    return $"{Path.GetFullPath(Constants.Constants.CAPTERRA_FILE_NAME)}";
                case SourceType.SoftwareAdvice:
                    return $"{Path.GetFullPath(Constants.Constants.SOFTWAREADVICE_FILE_NAME)}";
                default:
                    return string.Empty;
            }
        }
    }
}
