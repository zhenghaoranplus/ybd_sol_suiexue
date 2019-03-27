using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Appoa.Common
{
    public static class GMConvert
    {
        /*  GPS坐标转换为BaiduMap坐标
	        GpsLat  		GPS坐标纬度
	        GpsLon  		GPS坐标经度
	        MapLat          转换后的map坐标纬度  
	        MapLon          转换后的map坐标经度
        */
        [DllImport("GMConvert.dll", EntryPoint = "GpsToBaiduMap")]
        public static extern void GpsToBaiduMap(
                                            double GpsLon,
                                            double GpsLat,
                                            ref double MapLon,
                                            ref double MapLat);
        /*  BaiduMap坐标转换为GPS坐标
            MapLat          转换后的map坐标纬度  
            MapLon          转换后的map坐标经度
            GpsLat  		GPS坐标纬度
            GpsLon  		GPS坐标经度
        */
        [DllImport("GMConvert.dll", EntryPoint = "BaiduMapToGps")]
        public static extern void BaiduMapToGps(
                                            double MapLon,
                                            double MapLat,
                                            ref double GpsLon,
                                            ref double GpsLat);
    }
}
