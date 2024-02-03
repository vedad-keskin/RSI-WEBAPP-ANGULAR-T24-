
function napraviBox(m, imeKlase)
{
	if (m==="")
		return;
	var d = document.createElement("div");
	d.classList.add(imeKlase);
	d.innerHTML = m;
	var porukeKontejnerDiv = document.getElementById("porukeKontejnerDiv");
	if (porukeKontejnerDiv == null)
	{
		porukeKontejnerDiv = document.createElement("div");
		porukeKontejnerDiv.id = "porukeKontejnerDiv";
		d.classList.add("porukeKontejnerDiv");
		document.body.appendChild(porukeKontejnerDiv);
	}
	porukeKontejnerDiv.appendChild(d);
   
	setTimeout(function() {        
	  
		d.style.opacity = '0';
		setTimeout(function() {d.remove();}, 1000);
	}, 4000);
}

function porukaSuccess(m)
{
	napraviBox(m, "porukaSuccess");
}

function porukaWarning(m)
{
	napraviBox(m, "porukaWarning");
}
      
function porukaError(m)
{
	napraviBox(m, "porukaError");
}

function porukaInfo(m)
{
	napraviBox(m, "porukaInfo");
}
      
