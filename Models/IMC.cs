namespace Api.Models {
    public static class IMCExtensions {
        public static string ToFriendlyString(this double imc) {
            if (imc < 17) {
                return "Muito abaixo do peso";
            } else if (imc < 18.5) {
                return "Abaixo do peso";
            } else if (imc < 25) {
                return "Peso normal";
            } else if (imc < 30) {
                return "Sobrepeso";
            } else if (imc < 35) {
                return "Obesidade grau 1";
            } else if (imc < 40) {
                return "Obesidade grau 2";
            } else {
                return "Obesidade grau 3";
            }
        }
    }
}
