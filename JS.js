//---------------------------------------------------------------------------------------------------------

/* Faz com que ProximoCampo receba o foco após o QtdeCaracter do CampoAtual ser alcançado */
function AutoTabular(QtdeCaracter, CampoAtual, ProximoCampo) {
    //Campo = document.getElementsByID("CampoAtual");
    if (CampoAtual.value.length >= QtdeCaracter) {
        ProximoCampo.focus();
    }
}

//---------------------------------------------------------------------------------------------------------

/* Faz a tecla ENTER agir como TAB */
function TabularCampo(){

    var e = event;
    var oTarget = (e.target) ? e.target : e.srcElement;
    var campo = oTarget.id;
    var proximo_campo;

    for (var i = 0; i < document.forms[0].elements.length; i++) {
        if (document.forms[0].elements[i].name == campo) {
            if (document.forms[0].elements[i + 1] != null) {
                proximo_campo = "";
                proximo_campo = document.forms[0].elements[i + 1].name;
                if (proximo_campo.indexOf('[') != -1) {
                    proximo_campo = document.forms[0].elements[i + 2].name;
                }
            }
        }
    }

    var ie = (typeof window.ActiveXObject != 'undefined');

    if (ie) {
        code = event.keyCode;
    }
    else // Firefox
    {
        code = e.which;
    }
    if (code == 13) {
        if (campo == 'false' || campo == "" ) return false;
        var proximoControle = document.getElementById(proximo_campo);
        if (proximoControle != null) proximoControle.focus();
        return false;
    }
}

document.onkeydown = TabularCampo;

//---------------------------------------------------------------------------------------------------------

function CarregaFlash() {
	document.write('<OBJECT codeBase="https://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0"');
	document.write('height="102" width="796" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" VIEWASTEXT>');
	document.write('<PARAM NAME="_cx" VALUE="21061">');
	document.write('<PARAM NAME="_cy" VALUE="2699">');
	document.write('<PARAM NAME="FlashVars" VALUE="">');
	document.write('<PARAM NAME="Movie" VALUE="imagens/anima_topo.swf">');
	document.write('<PARAM NAME="Src" VALUE="imagens/anima_topo.swf">');
	document.write('<PARAM NAME="WMode" VALUE="Window">');
	document.write('<PARAM NAME="Play" VALUE="-1">');
	document.write('<PARAM NAME="Loop" VALUE="-1">');
	document.write('<PARAM NAME="Quality" VALUE="High">');
	document.write('<PARAM NAME="SAlign" VALUE="">');
	document.write('<PARAM NAME="Menu" VALUE="-1">');
	document.write('<PARAM NAME="Base" VALUE="">');
	document.write('<PARAM NAME="AllowScriptAccess" VALUE="always">');
	document.write('<PARAM NAME="Scale" VALUE="ShowAll">');
	document.write('<PARAM NAME="DeviceFont" VALUE="0">');
	document.write('<PARAM NAME="EmbedMovie" VALUE="0">');
	document.write('<PARAM NAME="BGColor" VALUE="">');
	document.write('<PARAM NAME="SWRemote" VALUE="">');
	document.write('<PARAM NAME="MovieData" VALUE="">');
	document.write('<PARAM NAME="SeamlessTabbing" VALUE="1">');
	document.write('<PARAM NAME="Profile" VALUE="0">');
	document.write('<PARAM NAME="ProfileAddress" VALUE="">');
	document.write('<PARAM NAME="ProfilePort" VALUE="0">');
	document.write('<embed src="imagens/anima_topo.swf" quality="high" pluginspage="https://www.macromedia.com/go/getflashplayer"');
	document.write('type="application/x-shockwave-flash" width="796" height="102"> </embed>');
	document.write('</OBJECT>');
}

//---------------------------------------------------------------------------------------------------------

function LimiteMaximoTextArea(OBJ, LIMITE) {
    if (OBJ.value.length < LIMITE) {
        return true;
    } else {
        return false;
    }
}

//---------------------------------------------------------------------------------------------------------

function soNumero() {
	/*var strCheck = '0123456789';
	var whichCode = (window.Event) ? event.which : event.keyCode;

	if (whichCode < 30) return true;
	key = String.fromCharCode(whichCode); // Valor para o código da Chave
	if (strCheck.indexOf(key) == -1) { return false; } // Chave inválida
	    else { return true; }*/

    var CodCar = event.keyCode;
    if (!(CodCar >= 48 && CodCar <= 57)) { event.returnValue = false; return false; }

    return true;
}

//---------------------------------------------------------------------------------------------------------

function confirmarExclusao() {
	if (confirm('Deseja realmente excluir ?')) {
		return true;
	}
	return false;
}

//---------------------------------------------------------------------------------------------------------

function validaCEP() {
	var strCheck = '0123456789-';
	var whichCode = (window.Event) ? event.which : event.keyCode;
	
	if(whichCode < 30) return true;
	key = String.fromCharCode(whichCode);
	if (strCheck.indexOf(key) == -1) return false;
}

//---------------------------------------------------------------------------------------------------------

function soNLetra() {
	var strCheck = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
	var whichCode = (window.Event) ? event.which : event.keyCode;
	
	if(whichCode < 30) return true;
	key = String.fromCharCode(whichCode);
	if (strCheck.indexOf(key) == -1) return false;
}

//---------------------------------------------------------------------------------------------------------

function soLetra() {
	var strCheck = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ';
	var whichCode = (window.Event) ? event.which : event.keyCode;
	
	if (whichCode < 30) {
	    return true;
	}
	
	key = String.fromCharCode(whichCode);
	if (strCheck.indexOf(key) == -1) {
	    return false;
	}

}

//---------------------------------------------------------------------------------------------------------

function AbrePOP(strLink, strTarget, strParametros, intLarguraJanela, intAlturaJanela) {
	// Setando variáveis que vão fazer com que o pop fique centralizado
	intLargura = screen.width;
   	intAltura = screen.height;
   	intLeft = (intLargura - intLarguraJanela) / 2;
    intTop = ((intAltura - intAlturaJanela) / 2) - 31;

    janela = window.open(strLink, strTarget, strParametros + ',width=' + intLarguraJanela + ',height=' + intAlturaJanela + ',left=' + intLeft + ',top=' + intTop + '');

    try {
	    janela.focus();
    } catch (e) {}
}

//---------------------------------------------------------------------------------------------------------

var intClique = 0;

function VerificaDuploClique() {
    intClique ++;
    
    if (intClique >= 2) {
        alert('Consulta sendo processada. Por favor, aguarde...');
        return false;
    } else {
        return true;
    }
}

//---------------------------------------------------------------------------------------------------------