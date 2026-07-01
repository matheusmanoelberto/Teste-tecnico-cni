export function renderizarResumo(elementoResumo, dados) {
  elementoResumo.innerHTML = `
    <h2>Resumo da solicitacao</h2>
    <p><strong>Solicitante:</strong> ${dados.nome}</p>
    <p><strong>Tipo de servico:</strong> ${dados.tipoServico}</p>
    <p><strong>Setor:</strong> ${dados.setor}</p>
    <p><strong>Descricao:</strong> ${dados.descricao}</p>
  `;
}

export function limparResumo(elementoResumo) {
  elementoResumo.innerHTML = "";
}
