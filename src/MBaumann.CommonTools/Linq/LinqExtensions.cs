using System;
using System.Collections.Generic;

namespace MBaumann.CommonTools.Linq
{
    public static class LinqExtensions
    {
        public static IEnumerable<IEnumerable<TSource>> Batch<TSource>(this IEnumerable<TSource> p_Source, int p_Size)
        {
            TSource[] v_Bucket = null;
            int v_Count = 0;

            foreach (var v_Item in p_Source)
            {
                if (v_Bucket == null)
                    v_Bucket = new TSource[p_Size];

                v_Bucket[v_Count++] = v_Item;

                if (v_Count != p_Size)
                    continue;

                yield return v_Bucket;

                v_Bucket = null;
                v_Count = 0;
            }

            if (v_Bucket != null && v_Count > 0)
            {
                Array.Resize(ref v_Bucket, v_Count);
                yield return v_Bucket;
            }
        }
    }
}