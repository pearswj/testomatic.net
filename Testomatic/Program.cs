using System;
using System.Text;

namespace Testomatic
{
  class MainClass
  {
    private const int ERROR_UNHANDLED_EXCEPTION = 128; // git uses 128 a lot, so why not

    public static int Main(string[] args)
    {
      // catch-all for unhandled exceptions
      AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(HandleUnhandledException);

      // for (int i = 0; i < args.Length; i++) {
      //   System.Console.WriteLine("{0}: {1}", i, args[i]);
      // }

      if (args.Length > 1)
      {
        Console.Error.WriteLine("I'm only listening to the first arg!");
      }
      else if (args.Length == 0)
      {
        Console.WriteLine("Usage: [mono] Testomatic.exe <return code>");
        Console.WriteLine("Hint: type `?` as the return code");
        Console.WriteLine(@"
 ;     /        ,--.
[""]   [""]  ,<  |__**|
/[_]\  [~]\/    |//  |
 ] [   OOO      /o|__|   Phs");
      }

      int n;
      if (args.Length > 0)
      {
        if (args[0] == "?")
        {
          throw new Exception("Whoops-a-daisy!");
        }
        else if (int.TryParse(args[0], out n))
        {
          Console.WriteLine("Exiting with return code: {0} ...", n);
          return n;
        }
      }

      return 0;
    }

    static void HandleUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
      //Console.WriteLine((e.ExceptionObject as Exception).Message, "Unhandled UI Exception");
      Console.WriteLine("Unhandled exception (exit code: {0}) ...", ERROR_UNHANDLED_EXCEPTION);
      // Environment.Exit(ERROR_UNHANDLED_EXCEPTION);
      Environment.ExitCode = ERROR_UNHANDLED_EXCEPTION;
    }
  }
}
