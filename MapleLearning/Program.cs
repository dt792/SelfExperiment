using System;
using System.Text;
using System.Runtime.InteropServices;

static class MapleEngine
{
    // interface callback definitions
    public delegate void TextCallBack(IntPtr data, int tag, IntPtr output);
    public delegate void ErrorCallBack(IntPtr data, IntPtr offset, IntPtr msg);
    public delegate void StatusCallBack(IntPtr data, IntPtr used, IntPtr alloc, double time);
    public delegate IntPtr ReadLineCallBack(IntPtr data, IntPtr debug);
    public delegate long RedirectCallBack(IntPtr data, IntPtr name, IntPtr mode);
    public delegate IntPtr StreamCallBack(IntPtr data, IntPtr stream, int nargs, IntPtr args);
    public delegate long QueryInterrupt(IntPtr data);
    public delegate IntPtr CallBackCallBack(IntPtr data, IntPtr output);

    public struct MapleCallbacks
    {
        public TextCallBack textCallBack;
        public ErrorCallBack errorCallBack;
        public StatusCallBack statusCallBack;
        public ReadLineCallBack readlineCallBack;
        public RedirectCallBack redirectCallBack;
        public StreamCallBack streamCallBack;
        public QueryInterrupt queryInterrupt;
        public CallBackCallBack callbackCallBack;
    }

    // OpenMaple API methods (there are many more commands in the API,
    // these are just the ones we are using in this example)
    [DllImport(@"maplec.dll")]
    public static extern IntPtr StartMaple(int argc, String[] argv, ref MapleCallbacks cb, IntPtr data, IntPtr info, byte[] err);
    [DllImport(@"maplec.dll")]
    public static extern IntPtr EvalMapleStatement(IntPtr kv, byte[] statement);
    [DllImport(@"maplec.dll")]
    public static extern IntPtr IsMapleStop(IntPtr kv, IntPtr obj);
    [DllImport(@"maplec.dll")]
    public static extern void StopMaple(IntPtr kv);
}


class MainApp
{

    // When evaluating something Maple will send all displayed
    // output through this function.
    public static void cbText(IntPtr data, int tag, IntPtr output)
    {
        //Console.WriteLine("tag is " + tag );
        string s = Marshal.PtrToStringAnsi(output);
        Console.WriteLine(s);
    }

    // When evaluating something Maple will send errors through this function.
    // If not defined, errors will go through the text callback.
    public static void cbError(IntPtr data, IntPtr offset, IntPtr msg)
    {
        //Console.WriteLine("offset is " + offset.ToInt32() );
        string s = Marshal.PtrToStringAnsi(msg);
        Console.WriteLine(s);
    }

    // When evaluating something Maple will send a message about resources
    // used once per garbage collection.  If you don't want to see these
    // messages, just comment out the WriteLine command inside.
    public static void cbStatus(IntPtr data, IntPtr used, IntPtr alloc, double time)
    {
        Console.WriteLine("cputime=" + time
          + "; memory used=" + used.ToInt64() + "kB"
          + " alloc=" + alloc.ToInt64() + "kB"
        );
    }

    public static void Main(string[] args)
    {

        MapleEngine.MapleCallbacks cb;
        byte[] err = new byte[2048];
        IntPtr kv;

        // pass -A2 which sets kernelopts(assertlevel=2) just to show
        // how in this example.  The corresponding argc parameter 
        // (the first argument to StartMaple) should then be 2
        // argv[0] should always be filled in with something.
        String[] argv = new String[2];
        argv[0] = "maple";
        argv[1] = "-A2";

        // only a textcallback is really needed here, but error and status
        // callbacks are also provided to show how to handle the IntPtr
        // arguments
        cb.textCallBack = cbText;
        cb.errorCallBack = cbError;
        cb.statusCallBack = cbStatus;
        cb.readlineCallBack = null;
        cb.redirectCallBack = null;
        cb.streamCallBack = null;
        cb.queryInterrupt = null;
        cb.callbackCallBack = null;

        try
        {
            kv = MapleEngine.StartMaple(2, argv, ref cb, IntPtr.Zero, IntPtr.Zero, err);
        }
        catch (DllNotFoundException e)
        {
            Console.WriteLine(e.ToString());
            return;
        }
        catch (EntryPointNotFoundException e)
        {
            Console.WriteLine(e.ToString());
            return;
        }

        // make sure we got a good kernel vector handle back
        if (kv.ToInt64() == 0)
        {
            // Maple didn't start properly.  The "err" parameter will be filled
            // in with the reason why (usually a license error)
            // Note that since we passed in a byte[] array we need to trim
            // the characters past \0 during conversion to string
            Console.WriteLine("Fatal Error, could not start Maple: "
                    + System.Text.Encoding.ASCII.GetString(err, 0, Array.IndexOf(err, (byte)0))
                );
            return;
        }

        Console.WriteLine("    |\\^/|     OpenMaple (Example Program)");
        Console.WriteLine("._|\\|   |/|_. Copyright (c) Maplesoft, a division of Waterloo Maple Inc. 2009");
        Console.WriteLine(" \\OPENMAPLE/  All rights reserved. Maple and OpenMaple are trademarks of");
        Console.WriteLine(" <____ ____>  Waterloo Maple Inc.");
        Console.WriteLine("      |       Type ? for help.");

        // set the default plot driver to something nicer than "char"
        MapleEngine.EvalMapleStatement(kv, Encoding.ASCII.GetBytes("plotsetup(maplet):"));

        for (; ; )
        {
            // display a command prompt and wait for user input
            Console.Write("> ");
            string expr = Console.ReadLine();

            // catch ?xxx and restate as help(xxx)
            if (expr.Substring(0, 1) == "?")
                expr = "help(" + expr.Substring(1, 0) + ");";

            // This evaluates the inputted expression and sends the text output
            // to the text callback (cbText).  It also returns a handle to the
            // result.  Use a colon to terminate the statement if you don't
            // want any output (a result is still returned).
            IntPtr val = MapleEngine.EvalMapleStatement(kv, Encoding.ASCII.GetBytes(expr + ";"));

            // check if user typed quit/done/stop
            if (MapleEngine.IsMapleStop(kv, val).ToInt32() != 0)
                break;
        }

        MapleEngine.StopMaple(kv);
    }
}