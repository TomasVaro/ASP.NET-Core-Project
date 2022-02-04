//class PersonBox extends React.Component {
//	render() {
//		return (
//			<div className="personBox">Hello, world! I am a person box!</div>
//		);
//	}
//}

//ReactDOM.render(<PersonBox />, document.getElementById('content'));


function GetAllPersonsss() {
	return (
		$.get("/Ajax/GetPersons", null, function (data) {
			//$("#Content").html(data);
		})
		//document.getElementById('errorMessages').innerHTML = "";
		);
}

//ReactDOM.render(<GetAllPersons />, document.getElementById('content'));

axios.get('/Ajax/GetPersons')
	.then(function (response) {
		// handle success
		console.log(response);
	})
	.catch(function (error) {
		// handle error
		console.log(error);
	})
	.finally(function () {
		// always executed
	});

class GetAllPersons extends React.Component {
	render() {
		return (
			<ul>
				<li>Apples</li>
				<li>Bananas</li>
				<li>Cherries</li>
			</ul>
			);
    }
}
ReactDOM.render(<GetAllPersons/>, document.getElementById('content'));