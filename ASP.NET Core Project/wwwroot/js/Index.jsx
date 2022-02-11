class Index extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            Personlist:[]
        }
    }

    componentDidMount() {
        this.getPerson()
    }
    getPerson = () => {
        fetch("/React/PersonList").then(response => response.json())
            .then(data => {
                this.setState({ Personlist: data })
            })
    }
    render() {
        const row = this.state.Personlist.map((list, i) => {
            /*debugger*/
            return (
                <tr key={i}>
                    <td>{list.personId}</td>
                    <td>{list.name}</td>
                    <td>{list.phone}</td>
                    <td>{list.cityId}</td>
                    <div className="float-right mr-4 mb-2">
                    <td> <button type="button" className="btn btn-primary detailsButton" data-bs-toggle="modal" data-bs-target="#PersonDetailModal">Details</button> </td>
                    </div>
                </tr>
            )
        })
        return (
            <div>
                <div className="float-right mr-4 mb-2">
                    <button type="button" className="btn btn-primary addButton" data-bs-toggle="modal" data-bs-target="#AddEditModal">Add</button>
                </div>
                <table className="table">
                    <thead className="table-dark">
                        <tr>
                            <th scope="col">Id</th>
                            <th scope="col">Name</th>
                            <th scope="col">Phone</th>
                            <th scope="col">CityId</th>
                        </tr>
                    </thead>
                    <tbody>
                        {row}
                    </tbody>
                </table>
                <AddEditPerson/>
            </div>
        )
    }
}
ReactDOM.render(<Index />, document.getElementById("Personlist"))