
using System;
using System.Numerics;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;


namespace Week2Assign
{
    public class Character
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Atk { get; }
        public int Def { get; }
        public int HP { get; }
        public int Gold { get; }

        public Character(string name, string job, int level, int atk, int def, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            HP = hp;
            Gold = gold;
        }
    }
    public class Item
    {
        public string Name { get; }
        public string Description { get; }
        public int Type { get; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int HP { get; set; }

        public bool IsEquiped { get; set; }

        public static int itemCnt = 0;

        public Item(string name, string description, int type, int atk, int def, int hp, bool isEquiped = false)
        {
            Name = name;
            Description = description;
            Type = type;
            Atk = atk;
            Def = def;
            HP = hp;
            IsEquiped = isEquiped;
        }
        
        public void PrintItemStatDescription(bool withNumber = false, int idx = 0)
        {
            Console.Write("-");
            //장착관리
            if (withNumber)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("{0}", idx);
                Console.ResetColor();
            }
            if (IsEquiped)
            {
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("E");
                Console.ResetColor();
                Console.Write("]");
                Console.Write(PadRightForMixedText(Name, 9));
            }
            else Console.Write(PadRightForMixedText(Name, 12));
            Console.Write(" I ");

            if (Atk != 0) Console.Write($"공격력{(Atk >= 0 ? "+" : "")}{Atk}");
            if (Def != 0) Console.Write($"방어력{(Def >= 0 ? "+" : "")}{Def}");
            if (HP != 0) Console.Write($"체력{(HP >= 0 ? "+" : "")}{HP}");

            Console.Write(" I ");
            Console.WriteLine(Description);
        }
        public static int GetPrintableLength(string str)
        {
            int length = 0;
            foreach (char c in str)
            {
                if (char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter)
                {
                    length += 2; //글자크기 한글2
                }
                else
                {
                    length += 1; //글자크기 한글외 1
                }
            }

            return length;
        }
        public static string PadRightForMixedText(string str, int totalLength)
        {
            int currentLength = GetPrintableLength(str);
            int padding = totalLength - currentLength;
            return str.PadRight(str.Length + padding);
        }
    }
    internal class Program
    {
        static Character _player;
        static Item[] _items;


        static void Main(string[] args)
        {
           
            GameDataSetting();
            PrintStartLogo();
            StartMenu();
        }

        static void GameDataSetting()
        {
            _player = new Character("chad", "전사", 1, 10, 5, 100, 1500);
            _items = new Item[20];
            AddItem(new Item("평상복", "평범한 옷입니다.", 0, 0, 2, 0));
            AddItem(new Item("목검", "나무가지로 만든 검입니다.", 0, 1, 0, 0));
            AddItem(new Item("모자", "외출용 모자 입니다.", 0, 0, 1, 1));
            AddItem(new Item("녹슨검", "나무가지보다는 강한 검입니다.", 0, 3, 0, 0));
            AddItem(new Item("철검", "무기로 사용하기위해 만들어진 검입니다.", 0, 6, 0, 0));
            AddItem(new Item("강철검", "매우튼튼하고 잘 벼려진 검입니다.", 0, 10, 1, 0));
            AddItem(new Item("가죽갑옷", "가죽으로 만든 갑옷입니다.", 0, 0, 4, 2));
            AddItem(new Item("철제갑옷", "튼튼하며 전신을 보호해줄수있는 갑옷입니다.", 0, 0, 8, 4));
            AddItem(new Item("군용갑옷", "군대에서 사용되는 양산형 갑옷입니다.", 0, 0, 12, 8));
            AddItem(new Item("가죽 투구", "외형은 투구라고해도 무방합니다.", 0, 0, 2, 2));
            AddItem(new Item("철제 투구", "튼튼합니다. 하지만 익숙하지않으면 앞이 잘 안보입니다.", 0, 0, 6, 4));
            AddItem(new Item("군용 투구", "군대에서 사용되는 양산형 투구입니다.", 0, 0, 10, 8));
            AddItem(new Item("기합용 머리띠", "착용하면 온몸에 힘이 솟아오르는 느낌이 듭니다.", 0, 2, 1, 1));

        }
        static void AddItem(Item item)
        {
            if (Item.itemCnt == 10) return;
            _items[Item.itemCnt] = item;
            Item.itemCnt++;
        }
        private static void PrintStartLogo()
        {
            Console.WriteLine("□■■■■■■■■■■■■■□□□■■□□□■■■■■■■□□□■■□□□□");
            Console.WriteLine("□■■□□□■■■□□□■■□□□■■■□□□□□■□□□□□□■■■□□□");
            Console.WriteLine("□■□□□□□□■□□□□■□□■■■■□□□□□■□□□□□■■■■□□□"); 
            Console.WriteLine("□■■■□□□□■□□□■■□□■■□■■□□□□■□□□□□■■□■■□□");
            Console.WriteLine("□□■■■■■□■■■■■■□■■□□■■□□□□■□□□□■■□□■■□□");
            Console.WriteLine("□□□□□□■■■□□□□□□■■■■■■□□□□■□□□□■■■■■■□□");
            Console.WriteLine("□□□□□□□■■□□□□□□■□□□□■■□□□■□□□□■□□□□■■□");
            Console.WriteLine("□■□□□□■■■□□□□□■■□□□□■■□□□■□□□■■□□□□■■□");
            Console.WriteLine("□■■■■■■■■□□□□□■■□□□□□■■□□■□□□■■□□□□□■■");
            Console.WriteLine("                            아무 키나 눌러주세요                            ");

            Console.ReadKey();

           
        }

        static void StartMenu()
        {
            
            Console.Clear();

            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("마왕성앞 최종마을에 오신 신참 여러분 환영합니다.");
            Console.WriteLine("이곳에서 모험으로 가기 전 정비를 할 수 있습니다.");
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("");
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("");

            switch (CheckIfValidinput(1, 2))
            {
                case 1:
                    StatusManu();
                    break;
                case 2:
                    inventoryManu();
                    break;
            }
        }

        static void inventoryManu()
        {
            Console.Clear();
            ShowHighlightedText("※인벤토리 - 장비");
            Console.WriteLine("보유중인 장비를 확인하고 장착할수있습니다.");
            Console.WriteLine("");
            Console.WriteLine("[장비 목록]");
            for (int i = 0; i < Item.itemCnt; i++) 
            {
                _items[i].PrintItemStatDescription(true, i+1);
            }
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("(숫자키) 장착");
            Console.WriteLine("");

            int keyinput = CheckIfValidinput(0, Item.itemCnt);
            switch (keyinput) 
            {
                case 0:
                    StartMenu();
                    break;
                default:
                    ToggleEquipStatus(keyinput-1);
                    inventoryManu();
                    break;
            }
        }
        
        
        static void ToggleEquipStatus(int idx)
        {
            _items[idx].IsEquiped = !_items[idx].IsEquiped;
        }


        static void StatusManu()
        {
            Console.Clear();

            ShowHighlightedText("※상태창");
            Console.WriteLine("캐릭터 정보");

            PrintTextWithHighlights("Lv. ", _player . Level . ToString("00"));
            Console.WriteLine("");
            Console.WriteLine("{0} ( {1} )", _player.Name, _player.Job);

            int BonusAtk = getSumBonusAtk();
            int BonusDef = getSumBonusDef();
            int BonusHP = getSumBonusHP();
            PrintTextWithHighlights("공격력 : ", _player.Atk.ToString(), BonusAtk > 0 ? string.Format("(+{0})", BonusAtk):"");
            PrintTextWithHighlights("방어력 : ", _player.Def. ToString(), BonusDef > 0 ? string.Format("(+{0})", BonusDef) : "");
            PrintTextWithHighlights("체력 : ", _player.HP. ToString(), BonusHP > 0 ? string.Format("(+{0})", BonusHP) : "");
            PrintTextWithHighlights("소지금 : ", _player.Gold. ToString());
            Console.WriteLine("");
            Console.WriteLine("0. 뒤로가기");
            Console.WriteLine("");
            switch (CheckIfValidinput(0, 0))
            {
                case 0:
                    StartMenu();
                    break;
                 
            }
         }

        static int getSumBonusAtk()
        {
            int sum = 0;
            for (int i = 0; i < Item.itemCnt; i++)
            {
                if (_items[i].IsEquiped) sum += _items[i].Atk;
            }
            return sum;
        }
        static int getSumBonusDef()
        {
            int sum = 0;
            for (int i = 0; i < Item.itemCnt; i++)
            {
                if (_items[i].IsEquiped) sum += _items[i].Def;
            }
            return sum;
        }
        static int getSumBonusHP()
        {
            int sum = 0;
            for (int i = 0; i < Item.itemCnt; i++)
            {
                if (_items[i].IsEquiped) sum += _items[i].HP;
            }
            return sum;
        }
        static void ShowHighlightedText(String Text) 
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(Text);
            Console.ResetColor();
        }

        static void PrintTextWithHighlights(string s1, string s2, string s3 = "")
        {
            Console.Write(s1);
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine(s2);
            Console.ResetColor();
            Console.WriteLine(s3);

        }

        static int CheckIfValidinput(int min, int max)
        {
            int keyinput;
            bool result;
            do
            {
                Console.WriteLine("원하시는 행동을 입력해주세요");
                result = int.TryParse(Console.ReadLine(), out keyinput);
            }
            while (result = false || CheckIfValidinput(keyinput, min, max) == false);
            return keyinput;
        }

        static bool CheckIfValidinput(int keyinput, int min, int max)
        {
            if (min <= keyinput && keyinput <= max) return true;
            return false;
        }
    }
}

    