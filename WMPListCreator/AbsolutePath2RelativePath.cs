using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMPListCreator
{
    class AbsolutePath2RelativePath
    {
        /// <summary>
        /// 绝对路径转换为相对路径
        /// </summary>
        /// <param name="absolutePath">当前的目录</param>
        /// <param name="relativeTo">指向的目标文件</param>
        /// <returns>从当前的目录指向目标文件的路径</returns>
        public static string A2R(string absolutePath, string relativeTo)
        {
            string[] absoluteDirectories = absolutePath.Split('\\');
            string[] relativeDirectories = relativeTo.Split('\\');

            //获取二者最短长度
            int length = absoluteDirectories.Length < relativeDirectories.Length ? absoluteDirectories.Length : relativeDirectories.Length;

            //出循环用
            int lastCommonRoot = -1;
            int index;

            //寻找相同路径
            for (index = 0; index < length; index++)
                if (absoluteDirectories[index] == relativeDirectories[index])
                    lastCommonRoot = index;
                else
                    break;

            //没有相同路径
            if (lastCommonRoot == -1)
                throw new ArgumentException(absolutePath + " 与 " + relativeTo + " 没有相同根目录");

            //建立相对路径
            StringBuilder relativePath = new StringBuilder();

            //增加“..”
            for (index = lastCommonRoot + 1; index < absoluteDirectories.Length; index++)
                if (absoluteDirectories[index].Length > 0)
                    relativePath.Append("..\\");

            //增加目录
            for (index = lastCommonRoot + 1; index < relativeDirectories.Length - 1; index++)
                relativePath.Append(relativeDirectories[index] + "\\");
            relativePath.Append(relativeDirectories[relativeDirectories.Length - 1]);

            return relativePath.ToString();
        }
    }
}
