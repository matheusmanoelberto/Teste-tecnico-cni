import "./styles/style.css";
import { renderizarPaginaSolicitacao } from "./pages/solicitacao-servico.js";
import {
  obterDadosFormulario,
  validarFormulario,
  limparFormulario
} from "./components/form-solicitacao.js";
import { exibirErro, limparErro } from "./components/mensagem-erro.js";
import { renderizarResumo, limparResumo } from "./components/resumo-solicitacao.js";

function iniciar() {
  const app = document.getElementById("app");
  app.innerHTML = renderizarPaginaSolicitacao();

  const formulario = document.getElementById("solicitacao-form");
  const elementoErro = document.getElementById("mensagem-erro");
  const elementoResumo = document.getElementById("resumo-solicitacao");

  formulario.addEventListener("submit", (evento) => {
    evento.preventDefault();

    limparErro(elementoErro);
    limparResumo(elementoResumo);

    const dados = obterDadosFormulario(formulario);
    const erro = validarFormulario(dados);

    if (erro) {
      exibirErro(elementoErro, erro);
      return;
    }

    renderizarResumo(elementoResumo, dados);
    limparFormulario(formulario);
  });
}

iniciar();
