﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// from something to obj file format.
    /// </summary>
    public interface IObjFormat
    {
        /// <summary>
        /// positions of triangles.
        /// </summary>
        /// <returns></returns>
        vec3[] GetPositions();

        /// <summary>
        /// indexes of triangles.
        /// </summary>
        /// <returns></returns>
        uint[] GetIndexes();
    }

    public static class IObjFormatExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="filename"></param>
        /// <param name="modelName"></param>
        public static void DumpObjFile(this IObjFormat model, string filename, string modelName = null)
        {
            vec3[] positions = model.GetPositions();
            uint[] indexes = model.GetIndexes();
            using (var stream = new System.IO.StreamWriter(filename))
            {
                stream.WriteLine(string.Format("# Generated by CSharpGL.IObjFormat {0}", DateTime.Now));
                stream.WriteLine("# " + (modelName == null ? "" : modelName));
                for (int i = 0; i < positions.Length; i++)
                {
                    stream.WriteLine();
                    var pos = positions[i];
                    stream.Write(string.Format("v {0} {1} {2}", pos.x, pos.y, pos.z));
                }
                for (int i = 0; i < indexes.Length; i += 3)
                {
                    stream.WriteLine();
                    stream.Write(string.Format("f {0} {1} {2}", indexes[i + 0] + 1, indexes[i + 1] + 1, indexes[i + 2] + 1));
                }
            }
        }
    }

}