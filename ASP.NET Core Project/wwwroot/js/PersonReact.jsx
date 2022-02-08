function WriteHead() {
	return (
		<table class="table">
			<thead>
				<tr>
					<th>Name</th>
					<th>Phone</th>
					<th>City</th>
					<th>Country</th>
					<th>Languages</th>
					<th>Action</th>
				</tr>
			</thead>
		</table>
		);
}
ReactDOM.render(<WriteHead />, document.getElementById('head'));


class MyComponent extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            isLoaded: false,
            error: null,
            persons: []
        };
    }

    componentDidMount() {
        var xhr = new XMLHttpRequest();
        xhr.addEventListener("readystatechange", () => {
            if (xhr.readyState === 4) {
                if (xhr.status === 200) {
                    // request succesful
                    var response = xhr.responseText,
                        json = JSON.parse(response);

                    this.setState({
                        isLoaded: true,
                        persons: json
                    });
                } else {
                    // error
                    this.setState({
                        isLoaded: true,
                        error: xhr.responseText
                    });
                }
            }
        });

        xhr.open("GET", "/React/GetPersons", true);
        xhr.send();
    }

    render() {
        var body;
        if (!this.state.isLoaded) {
            // yet loading
            body = <div>Loading...</div>;
        } else if (this.state.error) {
            // error
            body = <div>Error occured: {this.state.error}</div>
        } else {
            // success
            var persons = this.state.persons;
            var body = [];
            for (const element of persons) {
                body.push(<li>{element}</li>)
            }
        }
        return body;
    }
}

ReactDOM.render(
    <MyComponent  />,
    document.getElementById('content')
);









////class PersonBox extends React.Component {
////	render() {
////		return (
////			<div className="personBox">Hello, world! I am a person box!</div>
////		);
////	}
////}

////ReactDOM.render(
////	<PersonBox />, document.getElementById('content')
////);


//function GetAllPersonsss() {
//	return (
//		$.get("/Ajax/GetPersons", null, function (data) {
//			$("#Content").html(data);
//		})
//		    document.getElementById('errorMessages').innerHTML = "";
//		);
//}

//ReactDOM.render(
//	<GetAllPersons />, document.getElementById('content')
//);

//axios.get('/Ajax/GetPersons')
//	.then(function (response) {
//		// handle success
//		console.log(response);
//	})
//	.catch(function (error) {
//		// handle error
//		console.log(error);
//	})
//	.finally(function () {
//		// always executed
//	});

//class GetAllPersons extends React.Component {
//	render() {
//		return (
//			<ul>
//				<li>Apples</li>
//				<li>Bananas</li>
//				<li>Cherries</li>
//			</ul>
//			);
//    }
//}
//ReactDOM.render(<GetAllPersons />, document.getElementById('content'));

//function GetAllPersons() {
//	return (
//		<ul>
//			<li>Apples</li>
//			<li>Bananas</li>
//			<li>Cherries</li>
//		</ul>
//	);
//}
//ReactDOM.render(<GetAllPersons />, document.getElementById('content'));