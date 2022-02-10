////import React from 'react';
////import ReactDOM from 'react-dom';


function WriteHead() {
	return (
		<table className="table">
			<thead>
				<tr>
					<th>Name</th>
				</tr>
			</thead>
		</table>
		);
}
ReactDOM.render(<WriteHead />, document.getElementById('head'));


class ListPersons extends React.Component {
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
            //body.push(<tbody className="table"></tbody>);
            for (const element of persons) {
                body.push(
                    <tr>
                        <td className="table">{element}</td>
                        <td>
                            <button onClick={() => this.personDetails({ element })} className="table">Details</button>
                        </td>
                    </tr>)
            }
        }
        return body;
    }


    personDetails(element) {
        console.log(element)
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

        xhr.open("GET", "/React/PersonDetails", true);
        xhr.send();




        //<tr>
        //    <td className="table">Details</td>
        //</tr>
    }


}
ReactDOM.render(<ListPersons  />, document.getElementById('content'));


function WriteDetailsHead() {
    return (
        <table className="table">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Phone</th>
                    <th>City</th>
                    <th>Country</th>
                    <th>Languages</th>
                </tr>
            </thead>
        </table>
    );
}
ReactDOM.render(<WriteDetailsHead />, document.getElementById('detailshead'));


//function personDetails() {
//    return (
//        <tr>
//            <td className="table">Details</td>
//        </tr>
//    );
//}
//ReactDOM.render(<PersonDetails />, document.getElementById('details'));








//function ButtonClick() {
//    return (
//        <button onClick={this.PersonDetails}>Details</button>
//    );
//}
//ReactDOM.render(<ButtonClick />, document.getElementById('butt'));




//class Toggle extends React.Component {
//    constructor(props) {
//        super(props);
//        this.state = { isToggleOn: true };

//        // This binding is necessary to make `this` work in the callback
//        this.handleClick = this.handleClick.bind(this);
//    }

//    handleClick() {
//        this.setState(prevState => ({
//            isToggleOn: !prevState.isToggleOn
//        }));
//    }

//    render() {
//        return (
//            <button onClick={this.handleClick}>Details</button>
//        );
//    }
//}

//ReactDOM.render(<Toggle />, document.getElementById('butt'));












function Button() {
    return (<button onClick={PersonDetails}>Details</button>);
}
ReactDOM.render(<Button />, document.getElementById('button'));


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