using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XLToolLibrary.Utilities;
using XLWXLibrary.WXEntity.XmlEntity;

namespace ConsoleTest
{
    class Program
    {
        static void Main( string[ ] args )
        {
            //XmlOperationTest();
            //XmlOperationAccessTokenTest();
            Console.Write( new Random().Next( 100000000, 999999999 ) );
            Console.ReadKey();
        }

        //测试xml
        public static void XmlOperationAccessTokenTest()
        {
            XmlHelper<string> xo = new XmlHelper<string>( @"F:\ArvinProject\Server\Study\MvcProject\MvcDemo\ConsoleTest\bin\Debug\xmlConfig\Credential.xml" );
            List<Credential> listCredential = xo.GetObject<Credential>( "Credentials.Credential" );
            if(!string.IsNullOrEmpty(xo.XmlError))
            {
                Console.WriteLine(xo.XmlError );
            }
            else
            {
                foreach ( Credential c in listCredential )
                {
                    Console.WriteLine( c.ToString() );
                }

            }
           
            Console.Read();
        }

        /// <summary>
        /// 测试路由信息
        /// </summary>
        public static void XmlOperationTest()
        {
            XmlHelper<string> xo = new XmlHelper<string>( @"F:\ArvinProject\Server\Study\MvcProject\MvcDemo\ConsoleTest\bin\Debug\xmlConfig\RouteConfig.xml" );
            List<RouteItemEntity> listRIE = xo.GetObject<RouteItemEntity>( "RouteItems.RouteItem" );
            foreach ( RouteItemEntity rie in listRIE )
            {
                Console.WriteLine( rie.ToString() );
            }
            Console.Read();
        }
    }
}
