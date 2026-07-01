export function obterDadosFormulario(formulario) {
  return {
    nome: formulario.nome.value.trim(),
    tipoServico: formulario.tipoServico.value.trim(),
    setor: formulario.setor.value.trim(),
    descricao: formulario.descricao.value.trim()
  };
}

export function validarFormulario(dados) {
  if (!dados.nome || !dados.tipoServico || !dados.setor || !dados.descricao) {
    return "Preencha todos os campos antes de enviar.";
  }

  return "";
}

export function limparFormulario(formulario) {
  formulario.reset();
}
