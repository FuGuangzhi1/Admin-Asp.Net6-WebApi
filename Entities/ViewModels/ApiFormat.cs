namespace Entites.ViewModel
{
    public class ApiFormat
    {
        /// <summary>
        /// 0表示成功 1表示失败 2警告 3 提示
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public dynamic? Data { get; set; }
        /// <summary>
        /// 文字提示
        /// </summary>
        public string? Massage { get; set; }
        /// <summary>
        /// 数据行数
        /// </summary>
        public long? Total { get; set; }

        public static string StateDescribe
        {
            get
            {
                return "State 0 表示成功 1 表示失败 2 警告 3 提示 4 成功但是无提示状态";
            }
        }
    }
}
