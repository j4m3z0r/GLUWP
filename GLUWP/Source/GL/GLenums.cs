namespace GLUWP.ES20Enums
{
    public enum ShaderType : int
    {
        FragmentShader = 0x8B30,
        VertexShader = 0x8B31
    }

    public enum TextureUnit : int
    {
        Texture0 = 0x84c0,
        Texture1 = 0x84c1,
        Texture2 = 0x84c2,
        Texture3 = 0x84c3,
        Texture4 = 0x84c4,
        Texture5 = 0x84c5,
        Texture6 = 0x84c6,
        Texture7 = 0x84c7,
        Texture8 = 0x84c8,
        Texture9 = 0x84c9,
        Texture10 = 0x84ca,
        Texture11 = 0x84cb,
        Texture12 = 0x84cc,
        Texture13 = 0x84cd,
        Texture14 = 0x84ce,
        Texture15 = 0x84cf,
        Texture16 = 0x84d0,
        Texture17 = 0x84d1,
        Texture18 = 0x84d2,
        Texture19 = 0x84d3,
        Texture20 = 0x84d4,
        Texture21 = 0x84d5,
        Texture22 = 0x84d6,
        Texture23 = 0x84d7,
        Texture24 = 0x84d8,
        Texture25 = 0x84d9,
        Texture26 = 0x84da,
        Texture27 = 0x84db,
        Texture28 = 0x84dc,
        Texture29 = 0x84dd,
        Texture30 = 0x84de,
        Texture31 = 0x84df,
    }

    public enum TextureTarget : int
    {
        Texture1D = 0x0de0,
        Texture2D = 0x0de1
    }

    public enum TextureParameterName : int
    {
        TextureMagFilter = 0x2800,
        TextureMinFilter = 0x2801,
        TextureWrapS = 0x2802,
        TextureWrapT = 0x2803
    }

    public enum TextureMagFilter : int
    {
        Nearest = 0x2600,
        Linear = 0x2601
    }

    public enum TextureMinFilter : int
    {
        Nearest = 0x2600,
        Linear = 0x2601
    }

    public enum TextureWrapMode : int
    {
        Clamp = 0x2900,
        Repeat = 0x2901,
        ClampToBorder = 0x812d,
        ClampToEdge = 0x812f
    }

    public enum PixelType : int
    {
        Byte = 0x1400,
        UnsignedByte = 0x1401,
        Short = 0x1402,
        UnsignedShort = 0x1403,
        Int = 0x1404,
        UnsignedInt = 0x1405,
        Float = 0x1406,
        Double = 0x140A
    }

    public enum VertexAttribPointerType : int
    {
        Byte = 0x1400,
        UnsignedByte = 0x1401,
        Short = 0x1402,
        UnsignedShort = 0x1403,
        Int = 0x1404,
        UnsignedInt = 0x1405,
        Float = 0x1406,
        Double = 0x140A
    }

    public enum DrawElementsType : int
    {
        UnsignedByte = 0x1401,
        UnsignedShort = 0x1403,
        UnsignedInt = 0x1405
    }

    public enum PixelInternalFormat : int
    {
        Alpha = 0x1906,
        Rgb = 0x1907,
        Rgba = 0x1908,
        Luminance = 0x1909,
        LuminanceAlpha = 0x190a,
        Rgba16Ext = 0x805b // Needed to load 16 bit RGBA (ie 64 bits per texel) textures on ANGLE.
    }

    public enum PixelFormat : int
    {
        Alpha = 0x1906,
        Rgb = 0x1907,
        Rgba = 0x1908,
        Luminance = 0x1909,
        LuminanceAlpha = 0x190a
    }

    public enum ShaderParameter : int
    {
        ShaderType = 0x8B4F,
        DeleteStatus = 0x8B80,
        CompileStatus = 0x8B81,
        InfoLogLength = 0x8B84,
        ShaderSourceLength = 0x8B88
    }

    public enum GetProgramParameterName : int
    {
        LinkStatus = 0x8B82,
        InfoLogLength = 0x8B84
    }

    public enum ClearBufferMask : int
    {
        ColorBufferBit = 0x00004000,
        DepthBufferBit = 0x00000100,
        StencilBufferBit = 0x00000400
    }

    public enum EnableCap : int
    {
        Blend = 0x0be2,
        CullFace = 0x0b44,
        DepthTest = 0x0b71,
        Dither = 0x0bd0,
        PolygonOffsetFill = 0x8037,
        SampleAlphaToCoverage = 0x809e,
        SampleCoverage = 0x80a0,
        ScissorTest = 0x0c11,
        StencilTest = 0x0b90,
        Texture2D = 0x0de1
    }

    // TODO: remove invalid modes from each of src and dest.
    public enum BlendingFactorSrc : int
    {
        Zero = 0,
        One = 1,
        SrcColor = 0x0300,
        OneMinusSrcColor = 0x0301,
        DstColor = 0x0306,
        OneMinusDstColor = 0x0307,
        SrcAlpha = 0x0302,
        OneMinusSrcAlpha = 0x0303,
        DstAlpha = 0x0304,
        OneMinusDstAlpha = 0x0305,
        ConstantColor = 0x8001,
        OneMinusConstantColor = 0x8002,
        ConstantAlpha = 0x8003,
        OneMinusConstantAlpha = 0x8004,
        SrcAlphaSaturate = 0x0308
    }

    public enum BlendingFactorDest : int
    {
        Zero = 0,
        One = 1,
        SrcColor = 0x0300,
        OneMinusSrcColor = 0x0301,
        DstColor = 0x0306,
        OneMinusDstColor = 0x0307,
        SrcAlpha = 0x0302,
        OneMinusSrcAlpha = 0x0303,
        DstAlpha = 0x0304,
        OneMinusDstAlpha = 0x0305,
        ConstantColor = 0x8001,
        OneMinusConstantColor = 0x8002,
        ConstantAlpha = 0x8003,
        OneMinusConstantAlpha = 0x8004,
        SrcAlphaSaturate = 0x0308
    }

    public enum BlendEquationMode : int
    {
        FuncAdd = 0x8006,
        FuncSubtract = 0x800A,
        FuncReverseSubtract = 0x800B
    }

    public enum ErrorCode : int
    {
        NoError = 0,
        InvalidEnum = 0x0500,
        InvalidValue = 0x0501,
        InvalidOperation = 0x0502,
        StackOverflow = 0x0503,
        StackUnderflow = 0x0504,
        OutOfMemory = 0x0505
    }

    public enum BufferTarget : int
    {
        ArrayBuffer = 0x8892,
        ElementArrayBuffer = 0x8893
    }

    public enum BufferUsageHint : int
    {
        DynamicDraw = 0x88E8,
        StaticDraw = 0x88E4,
        StreamDraw = 0x88E0
    }

    public enum BeginMode : int
    {
        Points = 0x0000,
        LineStrip = 0x0003,
        LineLoop = 0x0002,
        Lines = 0x0001,
        TriangleStrip = 0x0005,
        TriangleFan = 0x0006,
        Triangles = 0x0004
    }

    public enum GetPName : int
    {
        ActiveTexture = 0x84e0,
        AliasedLineWidthRange = 0x846e,
        AliasedPointSizeRange = 0x846d,
        AlphaBits = 0x0d55,
        ArrayBufferBinding = 0x8894,
        Blend = 0x0be2,
        BlendColor = 0x8005,
        BlendDstAlpha = 0x80ca,
        BlendDstRgb = 0x80c8,
        BlendEquationAlpha = 0x883d,
        BlendEquationRgb = 0x8009,
        BlendSrcAlpha = 0x80cb,
        BlendSrcRgb = 0x80c9,
        BlueBits = 0x0d54,
        ColorClearValue = 0x0c22,
        ColorWritemask = 0x0c23,
        CompressedTextureFormats = 0x86a3,
        CullFace = 0x0b44,
        CullFaceMode = 0x0b45,
        CurrentProgram = 0x8b8d,
        DepthBits = 0x0d56,
        DepthClearValue = 0x0b73,
        DepthFunc = 0x0b74,
        DepthRange = 0x0b70,
        DepthTest = 0x0b71,
        DepthWritemask = 0x0b72,
        Dither = 0x0bd0,
        ElementArrayBufferBinding = 0x8895,
        FramebufferBinding = 0x8ca6,
        FrontFace = 0x0b46,
        GenerateMipmapHint = 0x8192,
        GreenBits = 0x0d53,
        ImplementationColorReadFormat = 0x8b9b,
        ImplementationColorReadType = 0x8b9a,
        LineWidth = 0x0b21,
        MaxCombinedTextureImageUnits = 0x8b4d,
        MaxCubeMapTextureSize = 0x851c,
        MaxFragmentUniformVectors = 0x8dfd,
        MaxRenderbufferSize = 0x84e8,
        MaxTextureImageUnits = 0x8872,
        MaxTextureSize = 0x0d33,
        MaxVaryingVectors = 0x8dfc,
        MaxVertexAttribs = 0x8869,
        MaxVertexTextureImageUnits = 0x8b4c,
        MaxVertexUniformVectors = 0x8dfb,
        MaxViewportDims = 0x0d3a,
        NumCompressedTextureFormats = 0x86a2,
        NumShaderBinaryFormats = 0x8df9,
        PackAlignment = 0x0d05,
        PolygonOffsetFactor = 0x8038,
        PolygonOffsetFill = 0x8037,
        PolygonOffsetUnits = 0x2a00,
        RedBits = 0x0d52,
        RenderbufferBinding = 0x8ca7,
        SampleAlphaToCoverage = 0x809e,
        SampleBuffers = 0x80a8,
        SampleCoverage = 0x80a0,
        SampleCoverageInvert = 0x80ab,
        SampleCoverageValue = 0x80aa,
        Samples = 0x80a9,
        ScissorBox = 0x0c10,
        ScissorTest = 0x0c11,
        ShaderBinaryFormats = 0x8df8,
        ShaderCompiler = 0x8dfa,
        StencilBackFail = 0x8801,
        StencilBackFunc = 0x8800,
        StencilBackPassDepthFail = 0x8802,
        StencilBackPassDepthPass = 0x0b96,
        StencilBackRef = 0x8ca3,
        StencilBackValueMask = 0x0b93,
        StencilBackWritemask = 0x0b98,
        StencilBits = 0x0d57,
        StencilClearValue = 0x0b91,
        StencilFail = 0x0b94,
        StencilFunc = 0x0b92,
        StencilPassDepthFail = 0x0b95,
        StencilPassDepthPass = 0x0b96,
        StencilRef = 0x0b97,
        StencilTest = 0x0b90,
        StencilValueMask = 0x0b93,
        StencilWritemask = 0x0b98,
        SubpixelBits = 0x0d50,
        TextureBinding2D = 0x8069,
        TextureBindingCubeMap = 0x8514,
        UnpackAlignment = 0x0cf5,
        Viewport = 0x0ba2
    }

}
