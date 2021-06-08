
const selCountries = document.getElementById('countries');	// select element
function loadCountries() {
	$.ajax({
		url: 'api/Country',
		success: function (result) {
			console.log(result);
			populateCountries(result);
		},
		error: function (xhr, status, error) {
			console.error(xhr);
		}
	});

}

function populateCountries(countries) {
	$(selCountries).empty();	// clear any pre-existing options.
	for (var i = 0; i < countries.length; ++i) {
		var country = countries[i];
		var option = document.createElement("OPTION");
		option.value = country.sISOCode;
		option.text = country.sName + ' (' + country.sISOCode + ')';
		selCountries.appendChild(option);
	}
}

$(document).ready(() => {
	loadCountries();
});

