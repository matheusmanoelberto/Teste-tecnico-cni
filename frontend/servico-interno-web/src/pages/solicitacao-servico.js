export function renderizarPaginaSolicitacao() {
  return `
<section class="card">
  <h1>Solicitacao de Servico Interno</h1>

  <form id="solicitacao-form" novalidate>
    <label for="nome">Nome do solicitante</label>
    <input id="nome" name="nome" type="text" placeholder="Digite o nome" />

    <label for="tipoServico">Tipo de servico</label>
    <input id="tipoServico" name="tipoServico" type="text" placeholder="Digite o tipo de servico" />

    <label for="setor">Setor</label>
    <input id="setor" name="setor" type="text" placeholder="Digite o setor" />

    <label for="descricao">Descricao do servico</label>
    <textarea id="descricao" name="descricao" rows="4" placeholder="Descreva o servico"></textarea>

    <button type="submit">Enviar solicitacao</button>
  </form>

  <div id="mensagem-erro" class="erro" aria-live="polite"></div>
  <div id="resumo-solicitacao" class="resumo"></div>
</section>
`;
}
