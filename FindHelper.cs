using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    /// <summary>
    /// 顺序表查找
    /// 折半查找/二分查找
    /// </summary>
    class FindHelper
    {

        /// <summary>
        /// 顺序查找
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        public static int Sequential_Search(List<int> arr, int key)
        {
            int index;
            int cout = arr.Count;
            for (index = 0; index < cout; index++)
            {
                if (arr[index] == key)
                {
                    return index;
                }
            }
            return -1;
        }
        /// <summary>
        /// 顺序表查找优化，
        /// 通过设置哨兵，省去每次循环判断i越界
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int Sequential_Search2(List<int> arr, int key)
        {
            int i = arr.Count - 1;
            if (arr[0] == key)
            {
                return 0;
            }
            else
            {
                arr[0] = key;
            }
            while (arr[i] != key)
            {
                i--;
            }
            i = i == 0 ? -1 : i;
            return i;
        }
        /// <summary>
        /// 折半查找/二分查找
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int Binary_Search(List<int>arr,int key)
        {
            int low, high, mid;
            low = 0;
            high = arr.Count - 1;
            while(low<=high)
            {
                mid = (low + high) / 2;
                if(key<arr[mid])
                {
                    high = mid - 1;
                }
                else if(key>arr[mid])
                {
                    low = mid + 1;
                }
                else
                {
                    return mid;
                }
            }
            return -1;
        }
    }
}
