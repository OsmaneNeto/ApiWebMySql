namespace ApiWebMySql3dsn{
    public class Produto{
        //Atributos (Propriedade)
        //Atalho: digitar a palvra prop e apertar TAB
        public int codigo { get; set; }
        public string nome{ get; set; }
        public double preco { get; set; }
        public int quantidadde { get; set; }
        //Construtor - Atalho:  Ctrl .
        public Produto(int codigo, string nome, double preco, int quantidadde)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.preco = preco;
            this.quantidadde = quantidadde;
        }

        //Construtor vazio
        public Produto() { }
    }
}
