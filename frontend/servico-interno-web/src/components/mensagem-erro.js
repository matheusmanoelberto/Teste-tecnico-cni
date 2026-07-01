export function exibirErro(elementoErro, mensagem) {
  elementoErro.textContent = mensagem;
}

export function limparErro(elementoErro) {
  elementoErro.textContent = "";
}
