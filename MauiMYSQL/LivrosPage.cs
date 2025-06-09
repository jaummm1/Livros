using MauiMYSQL.Models;

namespace MauiMYSQL;

public partial class LivrosPage : ContentPage
{
    Conecta banco = new Conecta();
    Livros livros = new Livros();

    public LivrosPage()
    {
        InitializeComponent();
        if (banco.Conexao())
        {
            lblStatus.Text = "Banco conectado com Sucesso!";
            if (livros.Livros_Consulta())
            {
                lstLivros.ItemsSource = livros.listaLivros;
            }
        }
        else
        {
            lblStatus.Text = banco.conexao_status;
        }
    }

    private void btnAdicionar(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtTituloLivro.Text))
        {
            DisplayAlert("Atenção", "Preencha o título do livro", "OK");
            return;
        }

        livros.Livros_Add(txtTituloLivro.Text, "Autor Desconhecido", "https://www.example.com/capa.png");

        if (livros.Livros_Consulta())
        {
            lstLivros.ItemsSource = null;
            lstLivros.ItemsSource = livros.listaLivros;
        }
    }
}