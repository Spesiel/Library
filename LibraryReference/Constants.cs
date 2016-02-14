﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Library.Resources
{
    /// <summary>
    /// Contains all the fixed elements used through the application
    /// </summary>
    public static class Constants
    {
        #region Fields + Properties

        public static ParallelOptions ParallelOptions => new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };

        /// <summary>
        /// Path to the folder containing the Cache
        /// </summary>
        public static readonly string CachePath = BasePath + Properties.CacheNamePrefix + Path.DirectorySeparatorChar;

        /// <summary>
        /// Path to the file containing the Settings
        /// </summary>
        public static readonly string SettingsFile = BasePath + Properties.SettingsFile;

        /// <summary>
        /// The base path for all the files
        /// </summary>
        //TOFIX Change the base folder path
        private static readonly string BasePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + Path.DirectorySeparatorChar;

        #endregion Fields + Properties

        #region Allowed Extensions

        public static string[] AllowedExtensionsImages() => new string[] { "JPG", "JPEG", "PNG", "GIF" };

        public static string[] AllowedExtensionsVideos() => new string[] { "MOV", "MP4", "AVI" };

        #endregion Allowed Extensions

        #region ExifData

        public static Dictionary<int, string> ExifData => new Dictionary<int, string>()
                {
                    // GPS values
                    {0x0000,"PropertyTagGpsVer"},
                    {0x0001,"PropertyTagGpsLatitudeRef"},
                    {0x0002,"PropertyTagGpsLatitude"},
                    {0x0003,"PropertyTagGpsLongitudeRef"},
                    {0x0004,"PropertyTagGpsLongitude"},
                    {0x0005,"PropertyTagGpsAltitudeRef"},
                    {0x0006,"PropertyTagGpsAltitude"},
                    {0x0007,"PropertyTagGpsGpsTime"},
                    {0x0008,"PropertyTagGpsGpsSatellites"},
                    {0x0009,"PropertyTagGpsGpsStatus"},
                    {0x000A,"PropertyTagGpsGpsMeasureMode"},
                    {0x000B,"PropertyTagGpsGpsDop"},
                    {0x000C,"PropertyTagGpsSpeedRef"},
                    {0x000D,"PropertyTagGpsSpeed"},
                    {0x000E,"PropertyTagGpsTrackRef"},
                    {0x000F,"PropertyTagGpsTrack"},
                    {0x0010,"PropertyTagGpsImgDirRef"},
                    {0x0011,"PropertyTagGpsImgDir"},
                    {0x0012,"PropertyTagGpsMapDatum"},
                    {0x0013,"PropertyTagGpsDestLatRef"},
                    {0x0014,"PropertyTagGpsDestLat"},
                    {0x0015,"PropertyTagGpsDestLongRef"},
                    {0x0016,"PropertyTagGpsDestLong"},
                    {0x0017,"PropertyTagGpsDestBearRef"},
                    {0x0018,"PropertyTagGpsDestBear"},
                    {0x0019,"PropertyTagGpsDestDistRef"},
                    {0x001A,"PropertyTagGpsDestDist"},
                    // Miscelaneous
                    {0x00FE,"PropertyTagNewSubfileType"},
                    {0x00FF,"PropertyTagSubfileType"},
                    {0x0100,"PropertyTagImageWidth"},
                    {0x0101,"PropertyTagImageHeight"},
                    {0x0102,"PropertyTagBitsPerSample"},
                    {0x0103,"PropertyTagCompression"},
                    {0x0106,"PropertyTagPhotometricInterp"},
                    {0x0107,"PropertyTagThreshHolding"},
                    {0x0108,"PropertyTagCellWidth"},
                    {0x0109,"PropertyTagCellHeight"},
                    {0x010A,"PropertyTagFillOrder"},
                    {0x010D,"PropertyTagDocumentName"},
                    {0x010E,"PropertyTagImageDescription"},
                    {0x010F,"PropertyTagEquipMake"},
                    {0x0110,"PropertyTagEquipModel"},
                    {0x0111,"PropertyTagStripOffsets"},
                    {0x0112,"PropertyTagOrientation"},
                    {0x0115,"PropertyTagSamplesPerPixel"},
                    {0x0116,"PropertyTagRowsPerStrip"},
                    {0x0117,"PropertyTagStripBytesCount"},
                    {0x0118,"PropertyTagMinSampleValue"},
                    {0x0119,"PropertyTagMaxSampleValue"},
                    {0x011A,"PropertyTagXResolution"},
                    {0x011B,"PropertyTagYResolution"},
                    {0x011C,"PropertyTagPlanarConfig"},
                    {0x011D,"PropertyTagPageName"},
                    {0x011E,"PropertyTagXPosition"},
                    {0x011F,"PropertyTagYPosition"},
                    {0x0120,"PropertyTagFreeOffset"},
                    {0x0121,"PropertyTagFreeByteCounts"},
                    {0x0122,"PropertyTagGrayResponseUnit"},
                    {0x0123,"PropertyTagGrayResponseCurve"},
                    {0x0124,"PropertyTagT4Option"},
                    {0x0125,"PropertyTagT6Option"},
                    {0x0128,"PropertyTagResolutionUnit"},
                    {0x0129,"PropertyTagPageNumber"},
                    {0x012D,"PropertyTagTransferFunction"},
                    {0x0131,"PropertyTagSoftwareUsed"},
                    {0x0132,"PropertyTagDateTime"},
                    {0x013B,"PropertyTagArtist"},
                    {0x013C,"PropertyTagHostComputer"},
                    {0x013D,"PropertyTagPredictor"},
                    {0x013E,"PropertyTagWhitePoint"},
                    {0x013F,"PropertyTagPrimaryChromaticities"},
                    {0x0140,"PropertyTagColorMap"},
                    {0x0141,"PropertyTagHalftoneHints"},
                    {0x0142,"PropertyTagTileWidth"},
                    {0x0143,"PropertyTagTileLength"},
                    {0x0144,"PropertyTagTileOffset"},
                    {0x0145,"PropertyTagTileByteCounts"},
                    {0x014C,"PropertyTagInkSet"},
                    {0x014D,"PropertyTagInkNames"},
                    {0x014E,"PropertyTagNumberOfInks"},
                    {0x0150,"PropertyTagDotRange"},
                    {0x0151,"PropertyTagTargetPrinter"},
                    {0x0152,"PropertyTagExtraSamples"},
                    {0x0153,"PropertyTagSampleFormat"},
                    {0x0154,"PropertyTagSMinSampleValue"},
                    {0x0155,"PropertyTagSMaxSampleValue"},
                    {0x0156,"PropertyTagTransferRange"},
                    {0x0200,"PropertyTagJPEGProc"},
                    {0x0201,"PropertyTagJPEGInterFormat"},
                    {0x0202,"PropertyTagJPEGInterLength"},
                    {0x0203,"PropertyTagJPEGRestartInterval"},
                    {0x0205,"PropertyTagJPEGLosslessPredictors"},
                    {0x0206,"PropertyTagJPEGPointTransforms"},
                    {0x0207,"PropertyTagJPEGQTables"},
                    {0x0208,"PropertyTagJPEGDCTables"},
                    {0x0209,"PropertyTagJPEGACTables"},
                    {0x0211,"PropertyTagYCbCrCoefficients"},
                    {0x0212,"PropertyTagYCbCrSubsampling"},
                    {0x0213,"PropertyTagYCbCrPositioning"},
                    {0x0214,"PropertyTagREFBlackWhite"},
                    {0x0301,"PropertyTagGamma"},
                    {0x0302,"PropertyTagICCProfileDescriptor"},
                    {0x0303,"PropertyTagSRGBRenderingIntent"},
                    {0x0320,"PropertyTagImageTitle"},
                    {0x5001,"PropertyTagResolutionXUnit"},
                    {0x5002,"PropertyTagResolutionYUnit"},
                    {0x5003,"PropertyTagResolutionXLengthUnit"},
                    {0x5004,"PropertyTagResolutionYLengthUnit"},
                    {0x5005,"PropertyTagPrintFlags"},
                    {0x5006,"PropertyTagPrintFlagsVersion"},
                    {0x5007,"PropertyTagPrintFlagsCrop"},
                    {0x5008,"PropertyTagPrintFlagsBleedWidth"},
                    {0x5009,"PropertyTagPrintFlagsBleedWidthScale"},
                    {0x500A,"PropertyTagHalftoneLPI"},
                    {0x500B,"PropertyTagHalftoneLPIUnit"},
                    {0x500C,"PropertyTagHalftoneDegree"},
                    {0x500D,"PropertyTagHalftoneShape"},
                    {0x500E,"PropertyTagHalftoneMisc"},
                    {0x500F,"PropertyTagHalftoneScreen"},
                    {0x5010,"PropertyTagJPEGQuality"},
                    {0x5011,"PropertyTagGridSize"},
                    {0x5012,"PropertyTagThumbnailFormat"},
                    {0x5013,"PropertyTagThumbnailWidth"},
                    {0x5014,"PropertyTagThumbnailHeight"},
                    {0x5015,"PropertyTagThumbnailColorDepth"},
                    {0x5016,"PropertyTagThumbnailPlanes"},
                    {0x5017,"PropertyTagThumbnailRawBytes"},
                    {0x5018,"PropertyTagThumbnailSize"},
                    {0x5019,"PropertyTagThumbnailCompressedSize"},
                    {0x501A,"PropertyTagColorTransferFunction"},
                    {0x501B,"PropertyTagThumbnailData"},
                    {0x5020,"PropertyTagThumbnailImageWidth"},
                    {0x5021,"PropertyTagThumbnailImageHeight"},
                    {0x5022,"PropertyTagThumbnailBitsPerSample"},
                    {0x5023,"PropertyTagThumbnailCompression"},
                    {0x5024,"PropertyTagThumbnailPhotometricInterp"},
                    {0x5025,"PropertyTagThumbnailImageDescription"},
                    {0x5026,"PropertyTagThumbnailEquipMake"},
                    {0x5027,"PropertyTagThumbnailEquipModel"},
                    {0x5028,"PropertyTagThumbnailStripOffsets"},
                    {0x5029,"PropertyTagThumbnailOrientation"},
                    {0x502A,"PropertyTagThumbnailSamplesPerPixel"},
                    {0x502B,"PropertyTagThumbnailRowsPerStrip"},
                    {0x502C,"PropertyTagThumbnailStripBytesCount"},
                    {0x502D,"PropertyTagThumbnailResolutionX"},
                    {0x502E,"PropertyTagThumbnailResolutionY"},
                    {0x502F,"PropertyTagThumbnailPlanarConfig"},
                    {0x5030,"PropertyTagThumbnailResolutionUnit"},
                    {0x5031,"PropertyTagThumbnailTransferFunction"},
                    {0x5032,"PropertyTagThumbnailSoftwareUsed"},
                    {0x5033,"PropertyTagThumbnailDateTime"},
                    {0x5034,"PropertyTagThumbnailArtist"},
                    {0x5035,"PropertyTagThumbnailWhitePoint"},
                    {0x5036,"PropertyTagThumbnailPrimaryChromaticities"},
                    {0x5037,"PropertyTagThumbnailYCbCrCoefficients"},
                    {0x5038,"PropertyTagThumbnailYCbCrSubsampling"},
                    {0x5039,"PropertyTagThumbnailYCbCrPositioning"},
                    {0x503A,"PropertyTagThumbnailRefBlackWhite"},
                    {0x503B,"PropertyTagThumbnailCopyRight"},
                    {0x5090,"PropertyTagLuminanceTable"},
                    {0x5091,"PropertyTagChrominanceTable"},
                    {0x5100,"PropertyTagFrameDelay"},
                    {0x5101,"PropertyTagLoopCount"},
                    {0x5102,"PropertyTagGlobalPalette"},
                    {0x5103,"PropertyTagIndexBackground"},
                    {0x5104,"PropertyTagIndexTransparent"},
                    {0x5110,"PropertyTagPixelUnit"},
                    {0x5111,"PropertyTagPixelPerUnitX"},
                    {0x5112,"PropertyTagPixelPerUnitY"},
                    {0x5113,"PropertyTagPaletteHistogram"},
                    {0x8298,"PropertyTagCopyright"},
                    {0x829A,"PropertyTagExifExposureTime"},
                    {0x829D,"PropertyTagExifFNumber"},
                    {0x8769,"PropertyTagExifIFD"},
                    {0x8773,"PropertyTagICCProfile"},
                    {0x8822,"PropertyTagExifExposureProg"},
                    {0x8824,"PropertyTagExifSpectralSense"},
                    {0x8825,"PropertyTagGpsIFD"},
                    {0x8827,"PropertyTagExifISOSpeed"},
                    {0x8828,"PropertyTagExifOECF"},
                    {0x9000,"PropertyTagExifVer"},
                    {0x9003,"PropertyTagExifDTOrig"},
                    {0x9004,"PropertyTagExifDTDigitized"},
                    {0x9101,"PropertyTagExifCompConfig"},
                    {0x9102,"PropertyTagExifCompBPP"},
                    {0x9201,"PropertyTagExifShutterSpeed"},
                    {0x9202,"PropertyTagExifAperture"},
                    {0x9203,"PropertyTagExifBrightness"},
                    {0x9204,"PropertyTagExifExposureBias"},
                    {0x9205,"PropertyTagExifMaxAperture"},
                    {0x9206,"PropertyTagExifSubjectDist"},
                    {0x9207,"PropertyTagExifMeteringMode"},
                    {0x9208,"PropertyTagExifLightSource"},
                    {0x9209,"PropertyTagExifFlash"},
                    {0x920A,"PropertyTagExifFocalLength"},
                    {0x927C,"PropertyTagExifMakerNote"},
                    {0x9286,"PropertyTagExifUserComment"},
                    {0x9290,"PropertyTagExifDTSubsec"},
                    {0x9291,"PropertyTagExifDTOrigSS"},
                    {0x9292,"PropertyTagExifDTDigSS"},
                    {0xA000,"PropertyTagExifFPXVer"},
                    {0xA001,"PropertyTagExifColorSpace"},
                    {0xA002,"PropertyTagExifPixXDim"},
                    {0xA003,"PropertyTagExifPixYDim"},
                    {0xA004,"PropertyTagExifRelatedWav"},
                    {0xA005,"PropertyTagExifInterop"},
                    {0xA20B,"PropertyTagExifFlashEnergy"},
                    {0xA20C,"PropertyTagExifSpatialFR"},
                    {0xA20E,"PropertyTagExifFocalXRes"},
                    {0xA20F,"PropertyTagExifFocalYRes"},
                    {0xA210,"PropertyTagExifFocalResUnit"},
                    {0xA214,"PropertyTagExifSubjectLoc"},
                    {0xA215,"PropertyTagExifExposureIndex"},
                    {0xA217,"PropertyTagExifSensingMethod"},
                    {0xA300,"PropertyTagExifFileSource"},
                    {0xA301,"PropertyTagExifSceneType"},
                    {0xA302,"PropertyTagExifCfaPattern"}
                };

        #endregion ExifData
    }
}
