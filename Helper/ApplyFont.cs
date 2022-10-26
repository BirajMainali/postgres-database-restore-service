using postgres_database_restore_tool.Providers;
using System.Windows.Forms;

namespace postgres_database_restore_tool.Helper
{
    internal static class ApplyFont
    {
        public static Control ApplyRegularFont(this Control control, float? size = null)
        {
            control.Font = FontProvider.GetRegularFont(size ?? control.Font.Size);
            return control;
        }

        public static Control ApplyBoldFont(this Control control, float? size = null)
        {
            control.Font = FontProvider.GetBoldFont(size ?? control.Font.Size);
            return control;
        }
    }
}
