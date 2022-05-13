using CadastroImuno.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CadastroImuno.Tests.TestandoImunizante
{
    [TestClass]
    public class TestesImunizante
    {
        [TestMethod]
        public void Inserindo_Fabricante_Invalido()
        {
            Imunizante imunizante = new Imunizante();

            string fabricanteInserido = "XPTO";
            string fabricanteEsperado = "PFIZER";

            var resultado = imunizante.Fabricante = fabricanteEsperado;

            Assert.AreNotEqual(fabricanteInserido, resultado);
        }

        [TestMethod]
        public void Inserindo_Fabricante_Valido()
        {
            Imunizante imunizante = new Imunizante();

            string fabricanteInserido = "SINOVAC";
            string fabricanteEsperado = "SINOVAC";

            var resultado = imunizante.Fabricante = fabricanteEsperado;

            Assert.AreEqual(fabricanteInserido, resultado);
        }


        [TestMethod]
        public void Inserindo_Ano_Lote_Apenas_Numeros()
        {
            string anoInserido = "2022";
            string validacaoAno = @"^\d+$";

            Assert.IsTrue(Regex.IsMatch(anoInserido, validacaoAno));
        }

        [TestMethod]
        public void Inserindo_Ano_Lote_Invalido()
        {
            string anoInserido = "aaaa";
            string validacaoAno = @"^\d+$";

            Assert.IsFalse(Regex.IsMatch(anoInserido, validacaoAno));
        }

        [TestMethod]
        public void Inserindo_Ano_Lote_Maior()
        {
            string anoInserido = "20202";
            anoInserido.Length.Equals(4);

            string anoEsperado = "2022";
            anoEsperado.Length.Equals(4);

            Assert.AreNotEqual(anoInserido, anoEsperado);
        }

        [TestMethod]
        public void Inserindo_Ano_Lote_Menor()
        {
            string anoInserido = "2";
            anoInserido.Length.Equals(4);

            string anoEsperado = "2022";
            anoEsperado.Length.Equals(4);

            Assert.AreNotEqual(anoInserido, anoEsperado);
        }

        [TestMethod]
        public void Id_Imunizante_Invalido()
        {
            var IdDigitado = "1";
            int IdEsperado = 1;

            Imunizante imunizante = new Imunizante();
            imunizante.Id = IdEsperado;

            Assert.AreNotEqual(IdDigitado, IdEsperado);
        }

        [TestMethod]
        public void Id_Imunizante_Valido()
        {
            var IdDigitado = 1;
            int IdEsperado = 1;

            Imunizante imunizante = new Imunizante();
            imunizante.Id = IdEsperado;

            Assert.AreEqual(IdDigitado, IdEsperado);
        }

    }
}
