const API_URL = "http://localhost:5084/api/livros";

window.onload = () => carregarLivros();

async function carregarLivros() {
  const resposta = await fetch(API_URL);
  const livros = await resposta.json();

  const lista = document.getElementById("listaLivros");
  lista.innerHTML = "";

  livros.forEach(livro => {
    const item = document.createElement("li");
    item.textContent = `${livro.titulo} - ${livro.autor} (R$ ${livro.preco})`;

    // Botão de excluir
    const botaoExcluir = document.createElement("button");
    botaoExcluir.textContent = "Excluir";
    botaoExcluir.style.marginLeft = "10px";
    botaoExcluir.onclick = () => excluirLivro(livro.id);

    item.appendChild(botaoExcluir);
    lista.appendChild(item);
  });
}

async function excluirLivro(id) {
  const confirmar = confirm("Deseja excluir este livro?");
  if (!confirmar) return;

  const resposta = await fetch(`${API_URL}/${id}`, {
    method: "DELETE"
  });

  if (resposta.ok) {
    alert("Livro excluído com sucesso!");
    carregarLivros();
  } else {
    alert("Erro ao excluir livro.");
  }
}

document.getElementById("livroForm").addEventListener("submit", async function (e) {
  e.preventDefault();

  const titulo = document.getElementById("titulo").value;
  const autor = document.getElementById("autor").value;
  const preco = parseFloat(document.getElementById("preco").value);

  const novoLivro = { titulo, autor, preco };

  const resposta = await fetch(API_URL, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(novoLivro)
  });

  if (resposta.ok) {
    alert("Livro adicionado com sucesso!");
    carregarLivros();
    document.getElementById("livroForm").reset();
  } else {
    alert("Erro ao adicionar livro.");
  }
});
