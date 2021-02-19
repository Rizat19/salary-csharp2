using System;
using System.Collections.Generic;

namespace ProjectUniOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Salary> workers = new List<Salary>();
            workers.Add(new Salary("Aisultan Erzhanov",440000,2010));
            workers.Add(new Salary("Damira Serikovna", 150000, 2016));
            workers.Add(new Salary("Alen Seitmatov", 200000, 2019));
            
            for (var i = 0; i < workers.Count; i++)
            {
                workers[i].IncomeTaxSalary(i+1);
                workers[i].TotalNumWorkingDayOfMonthFunction(6-i,1);
                Console.WriteLine(workers[i]);
                line();
            }

            string fio = workers[0].minSalary(workers[1]);
            Console.WriteLine($"2 сотрудник арасынан -{workers[0].Fio}, {workers[1].Fio}-Минимум жалакы алатын сотрудник: {fio}");

            fio = workers[0].minSalary(workers[2]);
            Console.WriteLine($"2 сотрудник арасынан -{workers[0].Fio}, {workers[2].Fio}-Минимум жалакы алатын сотрудник: {fio}");
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
            //4 апта тапсырмасы: 2.	қызметкерлер массивінің ішінен ағымдағы ай үшін есептелген ақша мөлшері 
            //ең аз болатын жұмысшыны қайтаратын әдіс құрыңыз.  
    
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
            this._totalNumWorkingDaysOfMonth = 0;
        }
        public Salary(string name, int salarySumUser, int yearOfEmploymentUser)
        {
            //конструктор с параметрами
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
            if (nMonth == 1)
            {
                _salarySumMonth = salary;
                _incomeTax = opv + ipn; 
                _amountsOfMoneyWithheld = salary-tazaTabys;
            }
            
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
        
        public string minSalary(Salary obj)
        {
            string sotrudnikMinSalary;
            if (salarySum<obj.salarySum)
            {
                sotrudnikMinSalary = FIO;
            }
            else
            {
                sotrudnikMinSalary = obj.FIO;
            }
            return sotrudnikMinSalary;
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