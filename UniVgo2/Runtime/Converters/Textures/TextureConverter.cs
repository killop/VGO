﻿// ----------------------------------------------------------------------
// @Namespace : UniVgo2.Converters
// @Class     : TextureConverter
// ----------------------------------------------------------------------
#nullable enable
namespace UniVgo2.Converters
{
    using NewtonVgo;
    using UnityEngine;

    /// <summary>
    /// Texture Converter
    /// </summary>
    public class TextureConverter : ITextureConverter
    {
        /// <summary>
        /// Get import texture.
        /// </summary>
        /// <param name="source">The source texture.</param>
        /// <param name="textureMapType">The texture map type.</param>
        /// <param name="metallicRoughness">The metallic roughness.</param>
        /// <returns></returns>
        public virtual Texture2D GetImportTexture(Texture2D source, VgoTextureMapType textureMapType, float metallicRoughness = -1.0f)
        {
            if (textureMapType == VgoTextureMapType.NormalMap)
            {
                //return new NormalMapConverter().GetImportTexture(source);

                // @notice no conversion.
                // Unity's normal map is same with glTF's.
                return CopyTexture2d(source, VgoColorSpaceType.Linear, converter: null);
            }
            else if (textureMapType == VgoTextureMapType.MetallicRoughnessMap)
            {
                return new MetallicRoughnessMapConverter(metallicRoughness).GetImportTexture(source);
            }
            else if (textureMapType == VgoTextureMapType.OcclusionMap)
            {
                return new OcclusionMapConverter().GetImportTexture(source);
            }
            else
            {
                return source;
            }
        }

        /// <summary>
        /// Get export texture.
        /// </summary>
        /// <param name="source">The source texture.</param>
        /// <param name="textureMapType">The texture map type.</param>
        /// <param name="colorSpaceType">The color space type.</param>
        /// <param name="metallicSmoothness">The metallic smoothness.</param>
        /// <returns></returns>
        public virtual Texture2D GetExportTexture(Texture2D source, VgoTextureMapType textureMapType, VgoColorSpaceType colorSpaceType, float metallicSmoothness = -1.0f)
        {
            if (textureMapType == VgoTextureMapType.NormalMap)
            {
                return new NormalMapConverter().GetExportTexture(source);
            }
            else if (textureMapType == VgoTextureMapType.MetallicRoughnessMap)
            {
                return new MetallicRoughnessMapConverter(metallicSmoothness).GetExportTexture(source);
            }
            else if (textureMapType == VgoTextureMapType.OcclusionMap)
            {
                return new OcclusionMapConverter().GetExportTexture(source);
            }
            else
            {
                return CopyTexture2d(source, colorSpaceType);
            }
        }

        /// <summary>
        /// Copy Texture2D.
        /// </summary>
        /// <param name="source">The source texture.</param>
        /// <param name="colorSpaceType">The color space type.</param>
        /// <param name="converter">The converter.</param>
        /// <returns>The copied Texture2D.</returns>
        protected virtual Texture2D CopyTexture2d(Texture2D source, VgoColorSpaceType colorSpaceType, Material? converter = null)
        {
            RenderTextureReadWrite readWrite =
                (colorSpaceType == VgoColorSpaceType.Linear) ? RenderTextureReadWrite.Linear : RenderTextureReadWrite.sRGB;

            var renderTexture = new RenderTexture(source.width, source.height, depth: 0, RenderTextureFormat.ARGB32, readWrite);

            using (var scope = new ColorSpaceScope(readWrite))
            {
                if (converter == null)
                {
                    Graphics.Blit(source, renderTexture);
                }
                else
                {
                    Graphics.Blit(source, renderTexture, converter);
                }
            }

            Texture2D dest = new Texture2D(source.width, source.height, TextureFormat.ARGB32, mipChain: false, linear: (readWrite == RenderTextureReadWrite.Linear));
            dest.ReadPixels(new Rect(x: 0, y: 0, source.width, source.height), destX: 0, destY: 0, recalculateMipMaps: false);
            dest.name = source.name;
            dest.anisoLevel = source.anisoLevel;
            dest.filterMode = source.filterMode;
            dest.mipMapBias = source.mipMapBias;
            dest.wrapMode = source.wrapMode;
            dest.wrapModeU = source.wrapModeU;
            dest.wrapModeV = source.wrapModeV;
            dest.wrapModeW = source.wrapModeW;
            dest.Apply();

            RenderTexture.active = null;

            if (Application.isEditor)
            {
                UnityEngine.Object.DestroyImmediate(renderTexture);
            }
            else
            {
                UnityEngine.Object.Destroy(renderTexture);
            }

            return dest;
        }
    }
}
