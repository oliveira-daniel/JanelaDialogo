using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextoDialogo : MonoBehaviour
{
	private Text textoDialogo;
	private string textoMesagem;
	private int posMensagem, posVetor;

	// Campo privado mas acessivel via Inspector
	[SerializeField]
	private float tempo;

    [SerializeField]
    private GameObject avancarBtn;

    [SerializeField]
    private string[] mensagens = {
		"Lorem ipsum dolor sit amet, consectetuer adipiscing elit.",
		"Nullam feugiat, turpis at pulvinar vulputate, erat libero tristique tellus.",
		"Aliquam erat volutpat."
	};

	// Use this for initialization
	void Start ()
	{
		// Vincular o componente de texto, onde a mensagem sera escrita
		textoDialogo = GetComponent<Text> ();

		ProximaMensagem ();
	}

	void Update() {
		if (Input.anyKeyDown) {
			// Debug.Log ("Escrever todo o texto!");
			textoDialogo.text = textoMesagem;
			posMensagem = textoMesagem.Length;
		}
	}
	
	public void ProximaMensagem ()
	{
		posMensagem = 0;

		// Desativar o botao de proxima mensagem
		avancarBtn.SetActive(false);

		// Armazenar o texto inicial
		textoMesagem = mensagens [posVetor];
		
		// Apagar o conteudo do dialogo
		textoDialogo.text = string.Empty;
		
		// Iniciar a escrita do texto
		StartCoroutine (EscreverTexto ());
	}

	IEnumerator EscreverTexto ()
	{
		// Continuar executando enquanto ainda existe texto
		if (posMensagem < textoMesagem.Length) {
			// Metodo responsavel por escrever na tela a mensagem
			textoDialogo.text += textoMesagem [posMensagem++];
			
			// Aguardar por um determinado tempo (em segundos)
			yield return new WaitForSeconds (tempo);

			// Chamar a funçao novamente
			StartCoroutine (EscreverTexto ());
		} else {
			posVetor++;
			// Verificar se continua para a proxima mensagem
			if (posVetor < mensagens.Length) {
				// Ativar o botao de proxima mensagem
				avancarBtn.SetActive(true);
			} else {
				avancarBtn.SetActive(false);
			}
		}
	}

}
