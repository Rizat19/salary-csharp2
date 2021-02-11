using System;

namespace ProjectUniOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Атын - жониниз: ");
            string fio = Console.ReadLine();
            Console.Write("\nАйлыгыныз 1-айдагы: ");
            int salary = int.Parse(Console.ReadLine());
            Console.Write("\nЖумыска турган жылыныз: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("\nКанша айдагы таза табысынызды билгиниз келеди, санын енгизиниз: ");
            int nmb = int.Parse(Console.ReadLine());
            Console.Write("\nАптасына канша кун жумыс истеисиз: ");
            int weekNmb = int.Parse(Console.ReadLine());
            Console.Write("\nЖумыстан канша кун калдыныз, санын енгизиниз: ");
            int notNmb = int.Parse(Console.ReadLine());
            
            Salary person1 = new Salary(fio, salary,year);
            
            // person1.Fio = "Lim Anna"; //set пайдалану
            // person1.SalarySum = 250000; //set пайдалану
            // person1.YearOfEmployment = 2015; //set пайдалану
            
            person1.IncomeTaxSalary(nmb);
            person1.TotalNumWorkingDayOfMonthFunction(weekNmb,notNmb); // есептеу 1 айдагы келетин кундерин
            line();
            while (true)
            {
                Console.WriteLine("Кажетти акпарат алу ушин реттик номерин енгизиниз: " +
                              "\n1. кызметкердин аты-жони "+
                              "\n2. жалакы сомасы (оклад) 1 ай ушин шарт бойынша "+
                              "\n3. жумыска орналасу жылы "+
                              "\n4. 1 айдагы табыс салыгы " + 
                              "\n5. 1 ай ишиндеги жалпы жумыс кундеринин саны " + 
                              "\n6. 1 ай ишиндеги жумыска келген кундеринин саны: " + 
                              "\n7. берилген айлар ушин есептелген жалакы " + 
                              "\n8. жалпы усталган акша молшерлери "+
                              "\n9. жалпы барлык акпаратты билгим келеди "+
                              "\n10. ешкандай акпарат кажет емес, шыгу ");
                line();
                int nmbChoice = int.Parse(Console.ReadLine());
                if (nmbChoice==10)
                {
                    Console.WriteLine("Жарайды, онда сау болыныз. Келеси кездескенше...");
                    break;
                }
                switch (nmbChoice)
                {
                    case 1:
                        Console.WriteLine(person1.Fio);
                        break;
                    case 2:
                        Console.WriteLine(person1.SalarySum);
                        break;
                    case 3:
                        Console.WriteLine(person1.YearOfEmployment);
                        break;
                    case 4:
                        Console.WriteLine(person1.IncomeTax/nmb);
                        break;
                    case 5:
                        Console.WriteLine(person1.TotalNumWorkingDaysOfMonth);
                        break;
                    case 6:
                        Console.WriteLine(person1.NumWorkingDaysOfMonth);
                        break;
                    case 7:
                        Console.WriteLine(person1.SalarySumMonth);
                        break;
                    case 8:
                        Console.WriteLine(person1.AmountsOfMoneyWithheld);
                        break;
                    case 9:
                        Console.WriteLine(person1.ToString());
                        break;
                    default:
                        Console.WriteLine("кате енгиздиниз, бундай акпарат жок!");
                        break;
                }

                Console.Write("Жалгастыргыныз келе ме, 1-иа, 0-жок шыгу:");
                int choiceNext = int.Parse(Console.ReadLine());
                if (choiceNext==0)
                {
                    line();
                    Console.WriteLine("Жарайды, онда сау болыныз. Келеси кездескенше");
                    break;
                }
                Console.WriteLine();
                line();
            }
        }

        static void line()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine();
        }
    }

    /*3-нұсқа
            Жалақы класын құрыңыз. Класта келесідей өрістер болу керек:
             қызметкердің аты-жөні, жалақы сомасы (оклад), жұмысқа орналасу жылы,
             көтерме пайызы, табыс салығы, ай ішіндегі жалпы жұмыс күндерінің саны, 
             ай ішіндегі жұмысқа келген күндерінің саны, белгілі ай үшін есептелген жалақы 
             мөлшері (жұмыс істеген күндерінің санына байланысты) және ұсталған ақша мөлшерлері. 
             Келесі әдістерді жүзеге асырыңыз:
            1.	есептелген жалақы мөлшерін анықтау; ұсталған ақша мөлшерін анықтау;
            2.	қолға берілетін ақша көлемін және жұмыс өтілін анықтау.*/
            //1. 3- апта тапсырмасы:класс өрістерін жабық түрде жариялап, оларға қатынасуға мүмкіндік беретін қасиеттерді құру.
    
    class Salary
    {
        private string FIO; // қызметкердің аты-жөні
        private int salarySum; // жалақы сомасы (оклад) 1 ай үшін шарт бойынша
        private int yearOfEmployment; // жұмысқа орналасу жылы
        private double _incomeTax; // табыс салығы
        private int _totalNumWorkingDaysOfMonth; // 1 ай ішіндегі жалпы жұмыс күндерінің саны
        private int _numWorkingDaysOfMonth; //1 ай ішіндегі жұмысқа келген күндерінің саны
        private int _salarySumMonth; // белгілі ай үшін есептелген жалақы мөлшері (жұмыс істеген күндерінің санына байланысты) 
        private double _amountsOfMoneyWithheld; // ұсталған ақша мөлшерлері

        public Salary()
        {
            //конструктор без параметра
            this.FIO = "defaultFIO";
            this.salarySum = 0;
            this.yearOfEmployment = 0;
        }
        public Salary(string name, int salarySumUser, int yearOfEmploymentUser)
        {
            //пконструктор с параметрами
            FIO = name;
            salarySum = salarySumUser;
            yearOfEmployment = yearOfEmploymentUser;
        }
        //аксессорлар/қасиеттер 
        public string Fio
        {
            
            set { FIO = value;}
            get {return FIO;}
        }

        public int SalarySum
        {
            set {salarySum = value;} 
            get {return salarySum;}
        }

        public int YearOfEmployment
        {
            get {return yearOfEmployment;} 
            set {yearOfEmployment = value;}
        }

        public double IncomeTax
        {
            get {return _incomeTax;}
        }

        public int TotalNumWorkingDaysOfMonth
        {
            get {return _totalNumWorkingDaysOfMonth;} 
        }

        public int NumWorkingDaysOfMonth
        {
            get { return _numWorkingDaysOfMonth; }
        }

        public int SalarySumMonth
        {
            get { return _salarySumMonth; }
        }

        public double AmountsOfMoneyWithheld
        {
            get { return _amountsOfMoneyWithheld; }
        }
    
        public void IncomeTaxSalary(int nMonth)
        {
            //табыс салығын есептеу үшін, алдымен таза табыс мөлшерін анықтау қажет
            //табыс салығы=шарт бойынша жалақы - таза табыс
            //таза табыс= шарт бойынша жалақы-(ОПВ+ИПН)

            int salary = salarySum;
            double opv = salary * 0.1;
            double ipn = (salary - opv - 42500) * 0.1;
            double tazaTabys = salary - (opv + ipn);
            _salarySumMonth = salary;
            _incomeTax = opv + ipn;
            _amountsOfMoneyWithheld = salary-tazaTabys;
            if (nMonth>1)
            {
                tazaTabys = (salary - (opv + ipn)) * nMonth;
                _incomeTax = (opv + ipn)*nMonth;
                _amountsOfMoneyWithheld = salary*nMonth-tazaTabys;
                _salarySumMonth = salary*nMonth;
            }
            // Console.WriteLine($"Шарт бойынша 1 айдагы жалакы молшери: {salary}, табыс салыгы 1айдагы: {opv+ipn}, жане 1 айдагы таза табыс: {tazaTabys/nMonth}");
            // Console.WriteLine($"Онда жалпы {nMonth}-ай ушин шарт бойынша жалакы молшери:{_salarySumMonth}," +
            //                   $"\n жане осы {nMonth}-ай ушин салык:{_incomeTax}, ал осы {nMonth}-айдагы таза табыс: {tazaTabys} ");
        }
        

        public void TotalNumWorkingDayOfMonthFunction(int nWorkingWeek, int notWorkingDayOfMonth)
        {
            //1аптада n-рет келсе, барлық жұмыс күндерінің саны орташа есеппен, 4*n
            _totalNumWorkingDaysOfMonth = 4 * nWorkingWeek;
            _numWorkingDaysOfMonth = _totalNumWorkingDaysOfMonth - notWorkingDayOfMonth;
        }
        public override string ToString()
        {
            int n = _salarySumMonth / salarySum;
            return $"кызметкердин аты-жони: {FIO}, " +
                $"\n1 айдагы жалакы сомасы (оклад): {salarySum}," +
                $"\nжумыска орналасу жылы: {yearOfEmployment}," +
                $"\n1 айдагы табыс салыгы: {_incomeTax/n}, " +
                $"\n1 ай ишиндеги жалпы жумыс кундеринин саны: {_totalNumWorkingDaysOfMonth}, " +
                $"\n1 ай ишиндеги жумыска келген кундеринин саны: {_numWorkingDaysOfMonth}, " +
                $"\nберилген айлар ушин есептелген жалакы: {_salarySumMonth}" +
                $"\nжалпы усталган акша молшерлери: {_amountsOfMoneyWithheld}";
        }
    }
    
}