using System;
using System.Collections.Generic;
using PractLogger.Logger;

namespace PractLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Log logger = new Log();
            logger.Info("Запуск программы");
            logger.Info("Обнаружилась ошибка",new Exception("Что-то неверно"));
            logger.Info("Обнаружилась ошибка",1,2,3,4,5,6,7);
            logger.Debug("для вывода информации, которая может быть полезной в процессе разработки и отладки приложения");
            logger.Debug("для вывода информации, которая ...", new Exception("NullRef"));
            logger.DebugFormat("для вывода информации, которая ...", 5,6,7,8,9,0);
            logger.Error("Обнаружен Error");
            logger.Error("Обнаружен Error с ошибкой",new Exception("NullRef"));
            logger.ErrorUnique("Обнаружен Error с ошибкой", new Exception("NullRef"));
            logger.ErrorUnique("Обнаружен Error с ошибкой", new Exception("OutOfRange"));
            logger.Fatal("Обнаружен фатал");
            logger.Fatal("Обнаружен фатал", new Exception("NullRef"));
            logger.Fatal("Обнаружен фатал1");
            logger.Warning("Обнаружен варнинг");
            logger.Warning("Обнаружен варнинг",new Exception("NullRef"));
            logger.WarningUnique("Обнаружен варнинг");
            logger.WarningUnique("Обнаружен варнинг1");
            logger.SystemInfo("Системная информация",new Dictionary<object, object>{
                { 1,"первое сообщение"},
                { 2,"второе сообщение"},
                { 3,"третье сообщение"}
            });
            Console.WriteLine("Hello World!");
        }
    }
}
