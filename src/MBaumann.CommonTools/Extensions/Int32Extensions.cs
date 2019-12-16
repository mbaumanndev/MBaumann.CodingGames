namespace MBaumann.CommonTools.Extensions
{
    public static class Int32Extensions
    {
        public static bool IsBetween(this int p_Value, int p_FirstBoundary, int p_SecondBoundary)
        {
            return (p_FirstBoundary <= p_Value && p_Value <= p_SecondBoundary) || (p_SecondBoundary <= p_Value && p_Value <= p_FirstBoundary);
        }
    }
}