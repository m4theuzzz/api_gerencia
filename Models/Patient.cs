namespace Api.Models
{
    public class Patient
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public char sexo { get; set; }
        private DateTime _nascimento;
        public DateTime nascimento { get { return _nascimento; } set { _nascimento = value; this.CalcularIdade(); } }
        public int idade { get; set; }
        public double altura { get; set; }
        public double peso { get; set; }
        public string cpf { get; set; }
        public double imc { get; set; }

        public Patient(
            int id,
            string nome,
            string sobrenome,
            char sexo,
            DateTime nascimento,
            double altura,
            double peso,
            string cpf
        )
        {
            this.id = id;
            this.nome = nome;
            this.sobrenome = sobrenome;
            this.sexo = sexo;
            this.nascimento = nascimento;
            this.altura = altura;
            this.peso = peso;
            this.cpf = cpf;

            this.CalcularIdade();
            this.CalcularIMC();
        }

        public double ObterPesoIdeal()
        {
            return (this.sexo == 'M') ? 72.7 * this.altura - 58 : 62.1 * this.altura - 44.7;
        }

        public double CalcularIMC()
        {
            if (this.altura == 0 || this.peso == 0) { return 0; }
            this.imc = this.peso / (this.altura * this.altura);
            return this.imc;
        }

        public int CalcularIdade()
        {
            this.idade = DateTime.Now.Year - this.nascimento.Year;
            return this.idade;
        }

        public String obterSituacaoIMC()
        {
            this.CalcularIMC();
            return IMCExtensions.ToFriendlyString(this.imc);
        }

        public bool ValidarCPF()
        {
            if (cpf.Length != 11) { return false; }
            return true;
        }

        public String ObterCPFOfuscado()
        {
            return "***." + cpf.Substring(3, 3) + ".***-**";
        }
    }
}
