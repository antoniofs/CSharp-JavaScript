//---------------------------------------------------------------------------------------------------------
//Variavel Global
temElementoSelecionado = false;
caixaTexto;
primeiraVez = true;

function Mascara(formato, objeto) {
    campo = eval(objeto);
	// CEP
	if (formato=='CEP'){
    	var CodCar = event.keyCode;
		if (CodCar < 48 || CodCar > 57) {
		    campo.focus();
			event.returnValue = false;
		}
		separador = '-'; 
		conjunto1 = 5;
		if (campo.value.length == conjunto1) {
		    campo.value = campo.value + separador;
		}
    }
    //CPF
    if (formato == 'CPF') {
        separador = '.';
        separador2 = '-';
        conjunto1 = 3;
        conjunto2 = 7;
        conjunto3 = 11;

        var CodCar = event.keyCode;
        if (!(CodCar >= 48 && CodCar <= 57)) { event.returnValue = false; return false; }

        if (campo.value.length == conjunto1) { campo.value = campo.value + separador; }
        if (campo.value.length == conjunto2) { campo.value = campo.value + separador; }
        if (campo.value.length == conjunto3) { campo.value = campo.value + separador2; }
    }
    //CNPJ
    if (formato == 'CNPJ') {
        separador = '.';
        separador2 = '/';
        separador3 = '-';
        conjunto1 = 2;
        conjunto2 = 6;
        conjunto3 = 10;
        conjunto4 = 15;
        conjunto5 = 17;

        var CodCar = event.keyCode;
        if (!(CodCar >= 48 && CodCar <= 57)) { event.returnValue = false; return false; }

        if (campo.value.length == conjunto1) { campo.value = campo.value + separador; }
        if (campo.value.length == conjunto2) { campo.value = campo.value + separador; }
        if (campo.value.length == conjunto3) { campo.value = campo.value + separador2; }
        if (campo.value.length == conjunto4) { campo.value = campo.value + separador3; }
    }

    //Valor numerico
	if (formato=='VALOR') {
		var CodCar = event.keyCode
		if (CodCar == 44) { campo.value = campo.value + ","; }
		if (CodCar == 46) { campo.value = campo.value + "."; }
		if (CodCar < 48 || CodCar > 57) { event.returnValue = false; }
	}

	//Valor inteiro
	if (formato=='INTEIRO') {
		var CodCar = event.keyCode
		if (CodCar < 48 || CodCar > 57) { event.returnValue = false; }
	}

	// DATA
	if (formato=='DATA') {
	    separador = '/';
	    conjunto1 = 2;
	    conjunto2 = 5;
	    if (campo.value.length != conjunto1 || campo.value.length != conjunto2) {
	        var CodCar = event.keyCode;
	        if ((CodCar < 48 || CodCar > 57) && CodCar != 13) { event.returnValue = false; }
	    }
	    if (campo.value.length == conjunto1) { campo.value = campo.value + separador; }
	    if (campo.value.length == conjunto2) { campo.value = campo.value + separador; }
	}

	// TELEFONE
	if (formato=='TELEFONE'){
		separador = '-'; 
		conjunto1 = 4;
		if (campo.value.length != conjunto1) {
		    var CodCar = event.keyCode
				
		    if (CodCar < 48 || CodCar > 57) { event.returnValue = false; }
    	}
	    if (campo.value.length == conjunto1) { campo.value = campo.value + separador; }
	}
		
	// HORA
	if (formato=='HORA') {
		separador = ':'; 
		conjunto1 = 2;
		conjunto2 = 5;
		if (campo.value.length != conjunto1) {
			var CodCar = event.keyCode
			
			if (CodCar < 48 || CodCar > 57) {
				event.returnValue = false
			}
		}
		if (campo.value.length == conjunto1) { campo.value = campo.value + separador; }
		if (campo.value.length == conjunto2) { campo.value = campo.value + separador; }
	}

	// HORA SIMPLES (hh:mm)
	if (formato=='HORA_SIMPLES') {
		separador = ':'; 
		conjunto1 = 2;
		if (campo.value.length != conjunto1) {
			var CodCar = event.keyCode
			
			if (CodCar < 48 || CodCar > 57) {
				event.returnValue = false
			}
		}
		if (campo.value.length == conjunto1) { campo.value = campo.value + separador; }
	}
	
	if(formato == 'DI/DSI/DTA')
	{
		separador = '/';
		separador2 = '-'; 
		conjunto1 = 2;
		conjunto2 = 10;
		if (campo.value.length != conjunto1 || campo.value.length != conjunto2) 
		{
			var CodCar = event.keyCode;
			
			//Só permite numero até a posição 11 e na posição 12 para frente só o caracter (*) 
			if ((CodCar < 48 || CodCar > 57) && (CodCar != 13) && (campo.value.length <= 11 || CodCar != 42) )
			{ 
				event.returnValue = false; 
			}
			
			//Depois 11 posição só pode caracter (*)
			if (campo.value.length > 11 && CodCar != 42)
			{
				 event.returnValue = false;
			}
		}
		
		if (campo.value.length == conjunto1) { campo.value = campo.value + separador; }
		if (campo.value.length == conjunto2) { campo.value = campo.value + separador2; }
    }

    if (formato == 'RE') {
        separador = '/';
        separador2 = '-';
        conjunto1 = 2;
        conjunto2 = 10;
        conjunto3 = 13;

        if (campo.value.length != conjunto1 || campo.value.length != conjunto2) {
            //Pega a tecla digidada 
            var CodCar = event.keyCode;
            //Só permite numero até a posição 11 e na posição 12 para frente só o caracter (*) 
            if ((CodCar < 48 || CodCar > 57)){
                event.returnValue = false;
                return false;
            }
        }

        if (campo.value.length == conjunto1) { campo.value = campo.value + separador; }
        if (campo.value.length == conjunto2) { campo.value = campo.value + separador2; }
    }

    if (formato == 'DDE') {
        separador = '/';
        conjunto1 = 10;
       

        if (campo.value.length != conjunto1) {
            //Pega a tecla digidada 
            var CodCar = event.keyCode;
            //Só permite numero até a posição 11 e na posição 12 para frente só o caracter (*) 
            if ((CodCar < 48 || CodCar > 57)) {
                event.returnValue = false;
                return false;
            }
        }

        if (campo.value.length == conjunto1) { campo.value = campo.value + separador; }
       
    }

    if (formato == 'NCM') {
        separador = '.';
        separador2 = '.';
        conjunto1 = 4;
        conjunto2 = 7;

        if (campo.value.length != conjunto1 || campo.value.length != conjunto2) {
            //Pega a tecla digidada 
            var CodCar = event.keyCode;
            //Só permite numero até a posição 11 e na posição 12 para frente só o caracter (*) 
            if ((CodCar < 48 || CodCar > 57)) {
                event.returnValue = false;
                return false;
            }
        }

        if (campo.value.length == conjunto1) { campo.value = campo.value + separador; }
        if (campo.value.length == conjunto2) { campo.value = campo.value + separador2; }
    }
}

//---------------------------------------------------------------------------------------------------------

function ValidaHora(objeto){
    var campo = objeto;
    var horaInfoUser = new String();
    horaInfoUser = campo.value;
	var h, m, hora;
	
	if(campo.value != "") {

        //Verifica a quantidade de 5 posição 
	    horaInfoUser = (horaInfoUser.length == 5) ? horaInfoUser + ':00' : horaInfoUser;
	    
        valida = true;
        hora = horaInfoUser;
		h = hora.substring(0,2);
		m = hora.substring(3,5);

    	//Verifica a quantidade de 8 posição 
		valida = (hora.length != 8) ? false : true;
		
        //Verifica se a Hora e maior que 24 ou
        //se os Minutos são maiores que 59.
        valida = (h > 24 || m > 59)?false:true;

        return valida;
		
	}
}

//---------------------------------------------------------------------------------------------------------	

function validaData(obj) {
	var resultado = true;
	var dia, mes, ano, MaxDia; 
	if (obj.value == '') resultado = false; 
	
	dia = obj.value.substring(0, 2); 
	mes = obj.value.substring(3, 5); 
	ano = obj.value.substring(6, obj.value.length); 
	
	if(mes <= 12 && mes >= 1) { 
		if(obj.value.length == 10) { 
			MaxDia = MaxDiasMes(mes, ano); 
			if (dia < 1 || dia > MaxDia) resultado = false; 
			if (ano <= 1900 || ano >= 2100) resultado = false;
		} else {  
			resultado = false; 
		} 
	} else { 
		resultado = false; 
	} 

	return resultado; 
}

//---------------------------------------------------------------------------------------------------------	

function MaxDiasMes(mes, ano){ 
	var DiasMes = new Array(0, 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31); 
	mes = mes - 0; 
	ano = ano - 0; 
	if (mes >= 1 && mes <= 12) { 
		if (mes == 2) {
			return (ano % 4) == 0 ? 29: 28; 
		}
		else {
			return DiasMes[mes]; 
		}
	}
	else {
		return 0;
	}
} 

//---------------------------------------------------------------------------------------------------------	

function ComparaData(INICIO, FIM) { 
	var data1 = new Date(INICIO.substring(6, 10) + '/' + INICIO.substring(3, 5) + '/' + INICIO.substring(0, 2))
	var data2 = new Date(FIM.substring(6, 10) + '/' + FIM.substring(3, 5) + '/' + FIM.substring(0, 2))

	var resultado = true;
	
	if (data1 > data2){
		resultado = false;
	}

	return resultado;
}
//---------------------------------------------------------------------------------------------------------

//---------------------------------------------------------------------------------------------------------	
//Retorna o intervalo de Dias entre duas Datas
//A ordem tem que ser correta (Menor Data - Maior Data)
function diferencaDias(valor1, valor2){
	//Cria um Arry
	valor1 = valor1.split("/");
  	valor2 = valor2.split("/");
  	
	//Transforma em Data formato yyyyMMdd
	//Obs.:Metodo "Date" visualiza (0,Janeiro), (1,Fevereiro)
	var data1 = new Date(valor1[2], valor1[1]-1, valor1[0])
	var data2 = new Date(valor2[2], valor2[1]-1, valor2[0])
	
	//Tira a diferença entre as datas (Menor Data - Maior Data) 
    var dif =
        Date.UTC(data1.getYear(),data1.getMonth(),data1.getDate(),0,0,0)
      - Date.UTC(data2.getYear(),data2.getMonth(),data2.getDate(),0,0,0);
    return Math.abs((dif / 1000 / 60 / 60 / 24));
}

//---------------------------------------------------------------------------------------------------------

function LetraMaiuscula(elemento) {
    if (elemento.value != "")
    {
        elemento.value = elemento.value.toUpperCase();
        return true;
    }
    else
    {
        return false;
    }

}


//---------------------------------------------------------------------------------------------------------	
//Valida entra na caixa de texto
//Opção só (letra) ou (numero)
function validaCampos(elemento) {

	//Recebe lista de campos para validação 
	var camposArray; 
	camposArray = elemento.value;
	
	//Recebe campo armazenado no array
	var campo, recFocu;
	
	//Verifica se há uma ocorrencia de erro 
	var faltaPre = false


	
	//varre o Array de Campos 
	if(camposArray == ""){
			elemento.style.backgroundColor = "#eeee99";
		
			if(faltaPre != true){
				faltaPre =true;
				recFocu = elemento;
			}
		}
		else
		{
	    elemento.style.backgroundColor = "white";
		}
	
	if(faltaPre == true){
		alert('Campo com Preenchimento obrigat\xf3rio!!!');
		recFocu.focus();
		temElementoSelecionado = true;
		caixaTexto = recFocu;
		return false;
	}
	else
	{
	    elemento.value = elemento.value.toUpperCase();
	    return true;
	    
	}
}

function noclick() {
    
    if(temElementoSelecionado == true)
    {
        caixaTexto.focus();
        return false;
    }
    else
    {
        return true;
    }

}

//**MUDANÇAS

//---------------------------------------------------------------------------------------------------------	
//Valida entra na caixa de texto
//Opção só (letra) ou (numero)
function validarSenha(elemento) {
    //Recebe lista de campos para validação 
    var camposArray;
    camposArray = elemento.value;

    //Recebe campo armazenado no array
    var campo, recFocu;

    //Verifica se há uma ocorrencia de erro 
    var faltaPre = false

    //varre o Array de Campos 
    if (camposArray == "") {
        elemento.style.backgroundColor = "#eeee99";

        if (faltaPre != true) {
            faltaPre = true;
            recFocu = elemento;
        }
    }
    else {
        elemento.style.backgroundColor = "white";
    }

    if (faltaPre == true) {
        alert('Campo com Preenchimento obrigat\xf3rio!!!');
        recFocu.focus();
        return false;
    }
    else {
        return true;

    }
}

//---------------------------------------------------------------------------------------------------------	
function caixaTexto(obj,tamanho,msg){
	var	campo = document.getElementById(obj);
	var texto = campo.value;
	
	if (texto.length > tamanho - 1)
	{
		alert(msg);
		return false;
	}	
}
//---------------------------------------------------------------------------------------------------------	
function FormataCpf(campo, teclapres){
	var strCheck = '0123456789.-';
	var whichCode = (window.Event) ? event.which : event.keyCode;

	if (whichCode < 30) return true;
	key = String.fromCharCode(whichCode); // Valor para o código da Chave
	if (strCheck.indexOf(key) == -1) { return false; } // Chave inválida
	    //else { return true; }

	var tecla = teclapres.keyCode;
	var vr = new String(campo.value);
	vr = vr.replace(".", "");
	vr = vr.replace("/", "");
	vr = vr.replace("-", "");
	tam = vr.length + 1;
	if (tecla != 14)
	{
		if (tam == 4)
		campo.value = vr.substr(0, 3) + '.';
		if (tam == 7)
		campo.value = vr.substr(0, 3) + '.' + vr.substr(3, 6) + '.';
		if (tam == 11)
		campo.value = vr.substr(0, 3) + '.' + vr.substr(3, 3) + '.' + vr.substr(7, 3) + '-' + vr.substr(11, 2);
	}
}
//---------------------------------------------------------------------------------------------------------	
function FormataDoisDecimal(campo, teclapres, tamanhoMaximo) {
    if (campo.value.length > tamanhoMaximo) return false;

    var strCheck = '0123456789';

    //Verifica se aceita um dos metodos (Incompatibilidade entre Navegador)
    //var whichCode = (window.Event) ? event.which : event.keyCode;

    var whichCode;

    if(window.event){
        whichCode = window.event.keyCode;
    } else if (event.which) {
        whichCode = event.which;
    } else if (event.keyCode) {
        whichCode = event.keyCode;
    } else {
        whichCode = teclapres.keyCode;
    }

    //Se o codigo ASCII e menor que trinta 
    if (whichCode < 30) return true;

    //Transforma o codigo ASCII para Caracter
    key = String.fromCharCode(whichCode);

    //Verifica se esta fora dos caracter aceitos  [0123456789.,]
    if (strCheck.indexOf(key) == -1) { return false; }

    //Pega a string   
    var vr = new String(campo.value);

    vr = vr + key;

    //Remove os caracteres [, / .]
    vr = vr.replace(",", "");
    vr = vr.replace(".", "");
    vr = vr.replace(".", "");

    //Recebe a quantidade de caracter	
    tam = vr.length;


    var valorFormatado = new String();
    var contAux = 0

    for (x = (tam - 1); x >= 0; x--) {

        if (contAux == 2) {
            valorFormatado = vr.charAt(x) + "," + valorFormatado;
            contAux++;
            continue;
        }

        if (contAux == 5) {
            valorFormatado = vr.charAt(x) + "." + valorFormatado;
            contAux++;
            continue;
        }

        if (contAux == 8) {
            valorFormatado = vr.charAt(x) + "." + valorFormatado;
            contAux++;
            continue;
        }

        if (contAux == 11) {
            valorFormatado = vr.charAt(x) + "." + valorFormatado;
            contAux++;
            continue;
        }


        valorFormatado = vr.charAt(x) + valorFormatado;

        contAux++;

    }

    campo.value = "";

    campo.value = valorFormatado;

    return false;

}
//---------------------------------------------------------------------------------------------------------	
function FormataTresDecimal(campo, teclapres, tamanhoMaximo) {
    if (campo.value.length > tamanhoMaximo) return false;

    var strCheck = '0123456789';

    //Verifica se aceita um dos metodos (Incompatibilidade entre Navegador)
    //var whichCode = (window.Event) ? event.which : event.keyCode;

    var whichCode;

    if (window.event) {
        whichCode = window.event.keyCode;
    } else if (event.which) {
        whichCode = event.which;
    } else if (event.keyCode) {
        whichCode = event.keyCode;
    } else {
        whichCode = teclapres.keyCode;
    }

    //Se o codigo ASCII e menor que trinta 
    if (whichCode < 30) return true;

    //Transforma o codigo ASCII para Caracter
    key = String.fromCharCode(whichCode);

    //Verifica se esta fora dos caracter aceitos  [0123456789.,]
    if (strCheck.indexOf(key) == -1) { return false; }

    //Pega a string   
    var vr = new String(campo.value);

    vr = vr + key;

    //Remove os caracteres [, / .]
    vr = vr.replace(",", "");
    vr = vr.replace(".", "");
    vr = vr.replace(".", "");

    //Recebe a quantidade de caracter	
    tam = vr.length;


    var valorFormatado = new String();
    var contAux = 0

    for (x = (tam - 1); x >= 0; x--) {

        if (contAux == 3) {
            valorFormatado = vr.charAt(x) + "," + valorFormatado;
            contAux++;
            continue;
        }

        if (contAux == 6) {
            valorFormatado = vr.charAt(x) + "." + valorFormatado;
            contAux++;
            continue;
        }

        if (contAux == 9) {
            valorFormatado = vr.charAt(x) + "." + valorFormatado;
            contAux++;
            continue;
        }

        if (contAux == 12) {
            valorFormatado = vr.charAt(x) + "." + valorFormatado;
            contAux++;
            continue;
        }


        valorFormatado = vr.charAt(x) + valorFormatado;

        contAux++;

    }

    campo.value = "";

    campo.value = valorFormatado;

    return false;

}
//---------------------------------------------------------------------------------------------------------	
function FormataTresDecimal2(valor) {

    //Pega a string 
    var vr = new String(valor);

    //Remove os caracteres [, / .]
    vr = vr.replace(",", "");
    vr = vr.replace(",", "");
    vr = vr.replace(".", "");
    vr = vr.replace(".", "");
    vr = vr.replace(".", "");

    var valorFormatado = new String();
    var contAux = 0;

    //Recebe a quantidade de caracter	
    tam = vr.length;
    if (tam <= 3) {
        var count = 4 - tam;
        for (x = 0; x < count; x++) {
            vr = "0" + vr;
        }
    }

    tam = vr.length;
    for (x = (tam - 1); x >= 0; x--) {

        if (contAux == 3) {
            valorFormatado = vr.charAt(x) + "," + valorFormatado;
            contAux++;
            continue;
        }

        if (contAux == 6) {
            valorFormatado = vr.charAt(x) + "." + valorFormatado;
            contAux++;
            continue;
        }

        if (contAux == 9) {
            valorFormatado = vr.charAt(x) + "." + valorFormatado;
            contAux++;
            continue;
        }

        if (contAux == 12) {
            valorFormatado = vr.charAt(x) + "." + valorFormatado;
            contAux++;
            continue;
        }


        valorFormatado = vr.charAt(x) + valorFormatado;

        contAux++;

    }

    return valorFormatado;

}
//---------------------------------------------------------------------------------------------------------	
function FormataDecimal2(valor) {

    //Pega a string 
    var vr = new String(valor);

    //Remove os caracteres [, / .]
    vr = vr.replace(",", "");
    vr = vr.replace(",", "");
    vr = vr.replace(".", "");
    vr = vr.replace(".", "");
    vr = vr.replace(".", "");

    var valorFormatado = new String();
    var contAux = 0;

    if (vr.length <= 2) vr += "00";

    //Recebe a quantidade de caracter	
    tam = vr.length;

    for (x = (tam - 1) ; x >= 0; x--) {

        if (contAux == 2) {
            valorFormatado = vr.charAt(x) + "," + valorFormatado;
            contAux++;
            continue;
        }

        if (contAux == 6) {
            valorFormatado = vr.charAt(x) + "." + valorFormatado;
            contAux++;
            continue;
        }

        if (contAux == 9) {
            valorFormatado = vr.charAt(x) + "." + valorFormatado;
            contAux++;
            continue;
        }

        if (contAux == 12) {
            valorFormatado = vr.charAt(x) + "." + valorFormatado;
            contAux++;
            continue;
        }


        valorFormatado = vr.charAt(x) + valorFormatado;

        contAux++;

    }

    return valorFormatado;

}
//---------------------------------------------------------------------------------------------------------	
function validacpf(cpf){
	var i; 
  
	s = cpf.value.replace(/\D+/g, ''); 
  
	var c = s.substr(0,9); 
  
	var dv = s.substr(9,2); 
  
	var d1 = 0; 
  
	for (i = 0; i < 9; i++) 
	{ 
		d1 += c.charAt(i)*(10-i); 
	} 
  
	if (d1 == 0)
	{ 
		//alert("CPF Inv\xe1lido. Tente novamente.");
		//cpf.focus(); 
		return false; 
	} 

	switch (s){
	
		case '00000000000':{
			//window.alert("CPF Inv\xe1lido. Tente novamente.");
	  		return false;
	  		//cpf.focus();
			break;
		}
		case '11111111111':{
			//window.alert("CPF Inv\xe1lido. Tente novamente.");
	  		//cpf.focus();
	  		return false;
			break;
		}
		case '22222222222':{
			//window.alert("CPF Inv\xe1lido. Tente novamente.");
			//cpf.focus();
	  		return false;
			break;
		}
		case '33333333333':{
			//window.alert("CPF Inv\xe1lido. Tente novamente.");
	  		//cpf.focus();
	  		return false;
			break;
		}
		case '44444444444':{
			//window.alert("CPF Inv\xe1lido. Tente novamente.");
			//cpf.focus();
	  		return false;
			break;
		}
		case '55555555555':{
			//window.alert("CPF Inv\xe1lido. Tente novamente.");
			//cpf.focus();
	  		return false;
			break;
		}
		case '66666666666':{
			//window.alert("CPF Inv\xe1lido. Tente novamente.");
			//cpf.focus();
	  		return false;
			break;
		}
		case '77777777777':{
			//window.alert("CPF Inv\xe1lido. Tente novamente.");
			//cpf.focus();
	  		return false;
			break;
		}
		case '88888888888':{
			//window.alert("CPF Inv\xe1lido. Tente novamente.");
			//cpf.focus();
	  		return false;
			break;
		}
		case '99999999999':{
			//window.alert("CPF Inv\xe1lido. Tente novamente.");
			//cpf.focus();
	  		return false;
			break;
		}
	}

  
	d1 = 11 - (d1 % 11); 
  
	if (d1 > 9) d1 = 0; 
  
	if (dv.charAt(0) != d1) 
	{ 
		//window.alert("CPF Inv\xe1lido. Tente novamente.");
		//cpf.focus();
		return false; 
	} 
  
	d1 *= 2; 
  
	for (i = 0; i < 9; i++) 
  
	{ 
		d1 += c.charAt(i)*(11-i); 
	} 
  
	d1 = 11 - (d1 % 11); 
  
	if (d1 > 9) d1 = 0; 
  
	if (dv.charAt(1) != d1) 
	{ 
		//window.alert("CPF Inv\xe1lido. Tente novamente.");
		//cpf.focus(); 
		return false; 
	} 
		return true; 
}
//---------------------------------------------------------------------------------------------------------	
function validacnpj(c) {

    var numeros, digitos, soma, i, resultado, pos, tamanho, digitos_iguais, cnpj = c.value.replace(/\D+/g, '');
    digitos_iguais = 1;
    if (cnpj.length != 14) {
        //window.alert("CNPJ Inv\xe1lido. Tente novamente.");
        //c.focus();
        return false;
    }

    for (i = 0; i < cnpj.length - 1; i++)
        if (cnpj.charAt(i) != cnpj.charAt(i + 1)) {
            digitos_iguais = 0;
            break;
        }
    if (!digitos_iguais) {
        tamanho = cnpj.length - 2
        numeros = cnpj.substring(0, tamanho);
        digitos = cnpj.substring(tamanho);
        soma = 0;
        pos = tamanho - 7;
        for (i = tamanho; i >= 1; i--) {
            soma += numeros.charAt(tamanho - i) * pos--;
            if (pos < 2)
                pos = 9;
        }
        resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
        if (resultado != digitos.charAt(0)) {
            //alert('CNPJ Inv\xe1lido. Tente novamente.');
            //c.focus();
            return false;
        }

        tamanho = tamanho + 1;
        numeros = cnpj.substring(0, tamanho);
        soma = 0;
        pos = tamanho - 7;
        for (i = tamanho; i >= 1; i--) {
            soma += numeros.charAt(tamanho - i) * pos--;
            if (pos < 2)
                pos = 9;
        }
        resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
        if (resultado != digitos.charAt(1)) {
            //alert('CNPJ Inv\xe1lido. Tente novamente.');
            //c.focus();
            return false;
        }
        else {
            // alert('CNPJ  OK !');
            return true;
        }
    }
    else {
        //window.alert('CNPJ Inv\xe1lido. Tente novamente.');
        //c.focus();
        return false;
    }
}
//---------------------------------------------------------------------------------------------------------	
function ValidaEmail(objTextBox){
    var er = new RegExp(/^[A-Za-z0-9_\-\.]+@[A-Za-z0-9_\-\.]{2,}\.[A-Za-z0-9]{2,}(\.[A-Za-z0-9])?/);
    if (typeof (objTextBox) == "string") {
        if (er.test(objTextBox)) { return true; }
    } else if (typeof (objTextBox) == "object") {
        if (er.test(objTextBox.value)) {
            return true;
        }
    } else {
        return false;
    }
}

//---------------------------------------------------------------------------------------------------------	
//Valida entra na caixa de texto
//Se o valor monetario esta dentro do formato
// Valor (financeiro, Português):
function doMoeda(pStr) {

    //Expressão Regular Valor (financeiro, Português);
    var reMoeda = /^\d{1,3}(\.\d{3})*\,\d{2}$/;

    if (reMoeda.test(pStr)) {
        return true;
    } else if (pStr != null && pStr != "") {
        return false;
    }
}
