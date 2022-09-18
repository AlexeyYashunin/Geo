using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoBaseDataDLL
{
    public struct Header
    {
        public int Version;//версия базы данных
        public char[] Name;//название/префикс для базы данных
        public ulong Timestamp;//время создания базы данных
        public int Records;//общее количество записей
        public uint Offset_ranges;//смещение относительно начала файла до начала списка записей геоинформацией
        public uint Offset_cities;//смещение относительно начала файла до начала индекса с сортировкой по названию городов
        public uint Offset_locations;//смещение относительно начала файла до начала списка записей о местоположении
    }
}
