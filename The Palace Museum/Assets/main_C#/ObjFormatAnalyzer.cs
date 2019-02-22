﻿using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Hont
{
    /*
     不同obj文件中的v，vn，vt，f的值要可能会变化，注意要修改其中的代码
         */
    public class ObjFormatAnalyzer
    {
        public struct Vector
        {
            public float X;
            public float Y;
            public float Z;
            //public float D;
            //public float E;
            //public float F;

        }

        public struct Vn
        {
            public float X;
            public float Y;
            public float Z;
        }

        public struct Vt
        {
            public float X;
            public float Y;
        }

        public struct FacePoint
        {
            public int VertexIndex;
            public int TextureIndex;
            //public int NormalIndex;
        }

        public struct Face
        {
            public FacePoint[] Points;
            public bool IsQuad;
        }

        public Vector[] VertexArr;
        public Vn[] VertexNormalArr;
        public Vt[] VertexTextureArr;
        public Face[] FaceArr;


        public void Analyze(string content)
        {
            content = content.Replace('\r', ' ').Replace('\t', ' ');

            var lines = content.Split('\n');
            var vertexList = new List<Vector>();
            var vertexNormalList = new List<Vn>();
            var vertexTextureList = new List<Vt>();
            var faceList = new List<Face>();

            for (int i = 0; i < lines.Length; i++)
            {
                var currentLine = lines[i];

                if (currentLine.Contains("#") || currentLine.Length == 0)
                {
                    continue;
                }

                if (currentLine.Contains("v "))
                {
                    var splitInfo = currentLine.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    vertexList.Add(new Vector() { X = float.Parse(splitInfo[1]), Y = float.Parse(splitInfo[2]), Z = float.Parse(splitInfo[3]) });
                    vertexNormalList.Add(new Vn() { X = float.Parse(splitInfo[4]), Y = float.Parse(splitInfo[5]), Z = float.Parse(splitInfo[6]) });
                    //宫殿的obj文件没有vn，但vn的值在v的后面，所以这里的查找赋值在v中进行，后三位的值为vn的值
                }
                else if (currentLine.Contains("vn "))
                {
                    var splitInfo = currentLine.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    vertexNormalList.Add(new Vn() { X = float.Parse(splitInfo[1]), Y = float.Parse(splitInfo[2]), Z = float.Parse(splitInfo[3]) });
                }
                else if (currentLine.Contains("vt "))
                {
                    var splitInfo = currentLine.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    vertexTextureList.Add(new Vt() { X = float.Parse(splitInfo[1]), Y = float.Parse(splitInfo[2]) });
                    //具体查看obj文件，这里是由于vt只有X，Y两个数，而v和vn有X,Y,Z三个数，如果这里写三个数的话会报错
                }

                else if (currentLine.Contains("f "))
                {
                    var splitInfo = currentLine.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    var isQuad = splitInfo.Length > 4;
                    var face1 = splitInfo[1].Split('/');
                    var face2 = splitInfo[2].Split('/');
                    var face3 = splitInfo[3].Split('/');
                    var face4 = isQuad ? splitInfo[4].Split('/') : null;
                    var face = new Face();
                    face.Points = new FacePoint[4];
                    face.Points[0] = new FacePoint() { VertexIndex = int.Parse(face1[0]), TextureIndex = int.Parse(face1[1])/*, NormalIndex = int.Parse(face1[2])*/ };
                    face.Points[1] = new FacePoint() { VertexIndex = int.Parse(face2[0]), TextureIndex = int.Parse(face2[1])/*, NormalIndex = int.Parse(face2[2]) */};
                    face.Points[2] = new FacePoint() { VertexIndex = int.Parse(face3[0]), TextureIndex = int.Parse(face3[1])/*, NormalIndex = int.Parse(face3[2])*/ };
                    face.Points[3] = isQuad ? new FacePoint() { VertexIndex = int.Parse(face4[0]), TextureIndex = int.Parse(face4[1])/*, NormalIndex = int.Parse(face4[2])*/ } : default(FacePoint);
                    face.IsQuad = isQuad;

                    faceList.Add(face);
                }
            }

            VertexArr = vertexList.ToArray();
            VertexNormalArr = vertexNormalList.ToArray();
            VertexTextureArr = vertexTextureList.ToArray();
            FaceArr = faceList.ToArray();
        }
    }
}
