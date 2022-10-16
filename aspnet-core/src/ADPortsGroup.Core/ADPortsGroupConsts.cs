using ADPortsGroup.Debugging;

namespace ADPortsGroup
{
    public class ADPortsGroupConsts
    {
        public const string LocalizationSourceName = "ADPortsGroup";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "98947d1afe934757affa27ec4fec34c3";
    }
}
