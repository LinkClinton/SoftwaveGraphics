﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareGraphics
{
    public class PixelShaderStage : BaseStage
    {
        private PixelShader pixelShader = null;

        public PixelShaderStage(GraphicsPipeline GraphicsPipeline) : base(GraphicsPipeline)
        {

        }

        public PixelShader PixelShader { get => pixelShader; set => pixelShader = value; }

        internal override void OnProcessStage(ref DrawCall drawCall)
        {
            //enum the pixel
            for (int i = 0; i < drawCall.Pixels.Length; i++)
            {
                UnitProperty unitProperty = drawCall.Pixels[i].UnitProperty;

                pixelShader.StartProcessUnit(ref unitProperty, GraphicsPipeline.InputAssemblerStage.InputData);

                drawCall.Pixels[i].UnitProperty = unitProperty;
            }
        }
    }

    class PixelShaderStageInstance : PixelShaderStage
    {
        public PixelShaderStageInstance(GraphicsPipeline GraphicsPipeline) : base(GraphicsPipeline)
        {

        }
    }
}
