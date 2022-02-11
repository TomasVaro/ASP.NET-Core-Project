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
        const row = this.state.Personlist.map((list,i) => {
            return (
                <tr key={i}>
                    <td>{list.personId}</td>
                    <td>{list.name}</td>
                    <td>{list.phone}</td>
                </tr>
                )
        })
        return (
            <div>
                <button type="button" className="btn btn-primary" data-bs-toggle="modal" data-bs-target="#AddEditModal">Add</button>
                <table className="table">
                    <thead className="table-dark">
                        <tr>
                            <th scope="col">Id</th>
                            <th scope="col">Name</th>
                            <th scope="col">Phone</th>
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