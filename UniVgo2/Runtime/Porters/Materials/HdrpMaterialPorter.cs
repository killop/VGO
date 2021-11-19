﻿// ----------------------------------------------------------------------
// @Namespace : UniVgo2.Porters
// @Class     : HdrpMaterialPorter
// ----------------------------------------------------------------------
namespace UniVgo2.Porters
{
    using NewtonVgo;
    using System;
    using UniHdrpShader;
    using UnityEngine;

    /// <summary>
    /// HDRP Material Porter
    /// </summary>
    public class HdrpMaterialPorter : MaterialPorterBase
    {
        #region Constructors

        /// <summary>
        /// Create a new instance of HdrpMaterialPorter.
        /// </summary>
        public HdrpMaterialPorter() : base() { }

        #endregion

        #region Public Methods (Export)

        /// <summary>
        /// Create a vgo material.
        /// </summary>
        /// <param name="material">A HDRP material.</param>
        /// <returns>A vgo material.</returns>
        public override VgoMaterial CreateVgoMaterial(Material material)
        {
            switch (material.shader.name)
            {
                case ShaderName.HDRP_Eye:
                    return CreateVgoMaterialFromHdrpEye(material);

                case ShaderName.HDRP_Hair:
                    return CreateVgoMaterialFromHdrpHair(material);

                case ShaderName.HDRP_Lit:
                    return CreateVgoMaterialFromHdrpLit(material);

                default:
                    throw new NotSupportedException(material.shader.name);
            }
        }

        /// <summary>
        /// Create a vgo material from a HDRP/Eye material.
        /// </summary>
        /// <param name="material">A HDRP/Eye material.</param>
        /// <returns>A vgo material.</returns>
        protected VgoMaterial CreateVgoMaterialFromHdrpEye(Material material)
        {
            //HdrpEyeDefinition definition = UniHdrpShader.Utils.GetParametersFromMaterial<HdrpEyeDefinition>(material);

            VgoMaterial vgoMaterial = new VgoMaterial()
            {
                name = material.name,
                shaderName = material.shader.name,
                renderQueue = material.renderQueue,
                isUnlit = false,
            };

            ExportProperties(vgoMaterial, material);

            ExportTextureProperty(vgoMaterial, material, Property.Texture2D_5F873FC1, VgoTextureMapType.Default, VgoColorSpaceType.Srgb);
            ExportTextureProperty(vgoMaterial, material, Property.Texture2D_B9F5688C, VgoTextureMapType.NormalMap, VgoColorSpaceType.Linear);
            ExportTextureProperty(vgoMaterial, material, Property.Texture2D_D8BF6575, VgoTextureMapType.Default, VgoColorSpaceType.Srgb);
            ExportTextureProperty(vgoMaterial, material, Property.Texture2D_4DB28C10, VgoTextureMapType.NormalMap, VgoColorSpaceType.Linear);

            ExportKeywords(vgoMaterial, material);

            return vgoMaterial;
        }

        /// <summary>
        /// Create a vgo material from a HDRP/Hair material.
        /// </summary>
        /// <param name="material">A HDRP/Hair material.</param>
        /// <returns>A vgo material.</returns>
        protected VgoMaterial CreateVgoMaterialFromHdrpHair(Material material)
        {
            //HdrpHairDefinition definition = UniHdrpShader.Utils.GetParametersFromMaterial<HdrpHairDefinition>(material);

            VgoMaterial vgoMaterial = new VgoMaterial()
            {
                name = material.name,
                shaderName = material.shader.name,
                renderQueue = material.renderQueue,
                isUnlit = false,
            };

            ExportProperties(vgoMaterial, material);

            ExportTextureProperty(vgoMaterial, material, Property.BaseColorMap, VgoTextureMapType.Default, VgoColorSpaceType.Srgb);
            ExportTextureProperty(vgoMaterial, material, Property.NormalMap, VgoTextureMapType.NormalMap, VgoColorSpaceType.Linear);
            ExportTextureProperty(vgoMaterial, material, Property.MaskMap, VgoTextureMapType.Default, VgoColorSpaceType.Srgb);
            ExportTextureProperty(vgoMaterial, material, Property.SmoothnessMask, VgoTextureMapType.Default, VgoColorSpaceType.Srgb);

            ExportKeywords(vgoMaterial, material);

            return vgoMaterial;
        }

        /// <summary>
        /// Create a vgo material from a HDRP/Lit material.
        /// </summary>
        /// <param name="material">A HDRP/Lit material.</param>
        /// <returns>A vgo material.</returns>
        protected VgoMaterial CreateVgoMaterialFromHdrpLit(Material material)
        {
            //HdrpLitDefinition definition = UniHdrpShader.Utils.GetParametersFromMaterial<HdrpLitDefinition>(material);

            VgoMaterial vgoMaterial = new VgoMaterial()
            {
                name = material.name,
                shaderName = material.shader.name,
                renderQueue = material.renderQueue,
                isUnlit = false,
            };

            ExportProperties(vgoMaterial, material);

            ExportTextureProperty(vgoMaterial, material, Property.BaseColorMap, VgoTextureMapType.Default, VgoColorSpaceType.Srgb);
            ExportTextureProperty(vgoMaterial, material, Property.MaskMap, VgoTextureMapType.Default, VgoColorSpaceType.Srgb);
            ExportTextureProperty(vgoMaterial, material, Property.NormalMap, VgoTextureMapType.NormalMap, VgoColorSpaceType.Linear);
            ExportTextureProperty(vgoMaterial, material, Property.NormalMapOS, VgoTextureMapType.NormalMap, VgoColorSpaceType.Linear);
            ExportTextureProperty(vgoMaterial, material, Property.HeightMap, VgoTextureMapType.HeightMap, VgoColorSpaceType.Linear);
            ExportTextureProperty(vgoMaterial, material, Property.DetailMap, VgoTextureMapType.Default, VgoColorSpaceType.Linear);
            ExportTextureProperty(vgoMaterial, material, Property.TangentMap, VgoTextureMapType.Default, VgoColorSpaceType.Srgb);
            ExportTextureProperty(vgoMaterial, material, Property.TangentMapOS, VgoTextureMapType.Default, VgoColorSpaceType.Srgb);
            ExportTextureProperty(vgoMaterial, material, Property.AnisotropyMap, VgoTextureMapType.Default, VgoColorSpaceType.Srgb);
            ExportTextureProperty(vgoMaterial, material, Property.SubsurfaceMaskMap, VgoTextureMapType.Default, VgoColorSpaceType.Srgb);
            ExportTextureProperty(vgoMaterial, material, Property.ThicknessMap, VgoTextureMapType.Default, VgoColorSpaceType.Srgb);
            ExportTextureProperty(vgoMaterial, material, Property.IridescenceThicknessMap, VgoTextureMapType.Default, VgoColorSpaceType.Srgb);
            ExportTextureProperty(vgoMaterial, material, Property.IridescenceMaskMap, VgoTextureMapType.Default, VgoColorSpaceType.Srgb);
            ExportTextureProperty(vgoMaterial, material, Property.CoatMaskMap, VgoTextureMapType.Default, VgoColorSpaceType.Srgb);
            ExportTextureProperty(vgoMaterial, material, Property.SpecularColorMap, VgoTextureMapType.Default, VgoColorSpaceType.Srgb);
            ExportTextureProperty(vgoMaterial, material, Property.EmissiveColorMap, VgoTextureMapType.EmissionMap, VgoColorSpaceType.Srgb);
            ExportTextureProperty(vgoMaterial, material, Property.DistortionVectorMap, VgoTextureMapType.Default, VgoColorSpaceType.Srgb);
            ExportTextureProperty(vgoMaterial, material, Property.TransmittanceColorMap, VgoTextureMapType.Default, VgoColorSpaceType.Srgb);
            ExportTextureProperty(vgoMaterial, material, Property.MainTex, VgoTextureMapType.Default, VgoColorSpaceType.Srgb);

            ExportKeywords(vgoMaterial, material);

            return vgoMaterial;
        }

        #endregion

        #region Public Methods (Import)

        /// <summary>
        /// Create a HDRP material.
        /// </summary>
        /// <param name="vgoMaterial">A vgo material.</param>
        /// <param name="shader">A HDRP shader.</param>
        /// <returns>A HDRP material.</returns>
        public override Material CreateMaterialAsset(VgoMaterial vgoMaterial, Shader shader)
        {
            switch (vgoMaterial.shaderName)
            {
                case ShaderName.HDRP_Eye:
                    break;
                case ShaderName.HDRP_Hair:
                    break;
                case ShaderName.HDRP_Lit:
                    break;
                default:
                    throw new NotSupportedException(vgoMaterial.shaderName);
            }

            Material material = base.CreateMaterialAsset(vgoMaterial, shader);

            SurfaceType? surfaceType = null;
            BlendMode? blendMode = null;

            if (vgoMaterial.intProperties != null)
            {
                if (vgoMaterial.intProperties.TryGetValue(Property.SurfaceType, out int intSurfaceType))
                {
                    surfaceType = (SurfaceType)intSurfaceType;
                }
                if (vgoMaterial.intProperties.TryGetValue(Property.BlendMode, out int intBlendMode))
                {
                    blendMode = (BlendMode)intBlendMode;
                }
            }

            if (vgoMaterial.floatProperties != null)
            {
                if (vgoMaterial.floatProperties.TryGetValue(Property.SurfaceType, out float floatSurfaceType))
                {
                    surfaceType = (SurfaceType)Convert.ToInt32(floatSurfaceType);
                }

                if (vgoMaterial.floatProperties.TryGetValue(Property.BlendMode, out float floatBlendMode))
                {
                    blendMode = (BlendMode)Convert.ToInt32(floatBlendMode);
                }
            }

            if (surfaceType.HasValue)
            {
                if (blendMode.HasValue)
                {
                    //UniHdrpShader.Utils.SetSurfaceType(material, surfaceType.Value, blendMode.Value);
                }
                else
                {
                    //UniHdrpShader.Utils.SetSurfaceType(material, surfaceType.Value);
                }
            }

            return material;
        }

        #endregion
    }
}