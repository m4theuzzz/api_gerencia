namespace Api.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Sobrenome { get; set; }
        public Char Sexo { get; set; }
        public DateTime Nascimento { get; set; }
        public int Idade { get; set; }
        public Double Altura { get; set; }
        public Double Peso { get; set; }
        public String CPF { get; set; }
        public Double IMC { get; set; }

        public Patient(
            int Id,
            String Nome,
            String Sobrenome,
            Char Sexo,
            DateTime Nascimento,
            Double Altura,
            Double Peso,
            String CPF
        )
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Sobrenome = Sobrenome;
            this.Sexo = Sexo;
            this.Nascimento = Nascimento;
            this.Altura = Altura;
            this.Peso = Peso;
            this.CPF = CPF;
            this.IMC = 0;
            this.CalcularIdade();
            this.CalcularIMC();
        }

        public double ObterPesoIdeal()
        {
            return (this.Sexo == 'M') ? 72.7 * this.Altura - 58 : 62.1 * this.Altura - 44.7;
        }

        public double CalcularIMC()
        {
            if (this.Altura == 0 || this.Peso == 0) { return 0; }
            this.IMC = this.Peso / (this.Altura * this.Altura);
            return this.IMC;
        }

        public int CalcularIdade()
        {
            this.Idade = DateTime.Now.Year - this.Nascimento.Year;
            return this.Idade;
        }

        public String obterSituacaoIMC()
        {
            this.CalcularIMC();
            return IMCExtensions.ToFriendlyString(this.IMC);
        }

        public bool ValidarCPF()
        {
            if (CPF.Length != 11) { return false; }
            return true;
        }

        public String ObterCPFOfuscado()
        {
            return "***." + CPF.Substring(3, 3) + ".***-**";
        }
    }
}
