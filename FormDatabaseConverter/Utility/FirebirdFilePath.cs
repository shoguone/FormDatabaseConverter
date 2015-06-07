using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FormDatabaseConverter.Utility
{
    public class FirebirdFilePath
    {

        private string dbExtension = Properties.Settings.Default.DBExtension;
        private string driveLetter = Properties.Settings.Default.InternalDriveLetter;
        private string serverAddress = Properties.Settings.Default.ExternalServerAddress;

        private static string _originalConnectionString;
        public static string OriginalConnectionString
        {
            get { return _originalConnectionString; }
            set { _originalConnectionString = value; }
        }

        private static string _originalPath;
        public static string OriginalPath
        {
            get { return _originalPath; }
            set { _originalPath = value; }
        }

        private string _connectionString;
        public string ConnectionString
        {
            get
            {
                //if (string.IsNullOrEmpty(_connectionString))
                //{
                //    string oldPair = Regex.Match(OriginalConnectionString, @"(?:database=).+?(?=;)").Value;
                //    _connectionString = OriginalConnectionString.Replace(oldPair, "database=" + InternalPath);

                //}
                return _connectionString;
            }
        }

        private string _path;
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        private string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        private string _internalDirectory;
        public string InternalDirectory
        {
            get { return _internalDirectory; }
            set { _internalDirectory = value; }
        }

        private string _externalDirectory;
        public string ExternalDirectory
        {
            get { return _externalDirectory; }
            set { _externalDirectory = value; }
        }

        //private string _internalPath;
        /// <summary>
        /// _internalDirectory + _fileName + dbExtension
        /// </summary>
        public string InternalPath
        {
            get { return _internalDirectory + _fileName + dbExtension; }
        }

        private int _year;
        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        private int _number;
        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        private string _yearString;
        public string YearString
        {
            get { return _yearString; }
            set { _yearString = value; }
        }

        private string _numberString;
        public string NumberString
        {
            get { return _numberString; }
            set { _numberString = value; }
        }



        public FirebirdFilePath()
        {

        }

        /// <summary>
        /// Конструктор однако.
        /// Если знаем путь к файлу, создаем запись по пути, если не знаем, то по ConnectionString
        /// </summary>
        /// <param name="param">Либо ConnectionString, либо Path, в зависимости от isFromConnectionString</param>
        /// <param name="isFromConnectionString">Если true, то ConnectionString, иначе - ConnectionString</param>
        public FirebirdFilePath(string param, bool isFromConnectionString)
        {
            if (isFromConnectionString)
            {
                try
                {
                    _path = Regex.Match(param, @"(?:database=)(?<thisone>.+?)(?=;)").Groups["thisone"].Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("В строке подключения не найден путь к базе данных" +
                        " ('database=DatabaseAddressHere')\nТекст ошибки:\n", ex);
                }

                if (string.IsNullOrEmpty(_originalConnectionString))
                {
                    _originalConnectionString = param;
                    _originalPath = _path;
                }
            }
            else
            {
                _path = param;
            }


            _fileName = Regex.Match(_path, @"[^\\]+(?=" + Regex.Escape(dbExtension) + ")").Value;

            string directory = Regex.Match(_path, @".+(?=" + Regex.Escape(_fileName) + ")").Value;
            string letter = Regex.Match(directory, @"^\\*[^\\]+?(?=\\)").Value;

            _internalDirectory = directory.Replace(letter, driveLetter + ":");
            _externalDirectory = directory.Replace(letter, serverAddress);

            var numbers = _fileName.Split('-');
            if (numbers.Count() < 2)
            {
                numbers = new string[2];
                if (_fileName.Length > 8)
                {
                    numbers[0] = _fileName.Substring(0, 8);
                    numbers[1] = _fileName.Substring(8);
                }
                else
                {
                    numbers[0] = numbers[1] = _fileName;
                }
            }
            _yearString = Regex.Match(Regex.Escape(numbers[0]), @"\d+").Value;
            _numberString = numbers[1];
            int.TryParse(_yearString, out _year);
            int.TryParse(_numberString, out _number);

            _connectionString = _originalConnectionString.Replace(_originalPath, InternalPath);
        }

    }
}
