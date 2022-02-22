class PersonDetails extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            Name: '',
            Phone: '',
            CityId: ''
            //City: '',
            //Country: '',
            //Language: ''
        }
    }
    onSubmitting = (e) => {
        //debugger
        e.preventDefault();
        const data = {
            Name: this.state.Name,
            Phone: this.state.Phone,
            CityId: this.state.CityId
            //City: this.state.City,
            //Language: this.state.Language,
        }


        console.log("Submitted data", this.state)
        console.log("Json data", JSON.stringify(this.state))
        fetch("/React/AddEditPerson", {
            method: "POST",
            headers: { 'Content-Type': 'application/json', },
            body: JSON.stringify(data),
        })
        //.then(response => response.json())
        //.then(data => {
        //    console.log("Success", data.success);
        //    alert(data.Message)
        //    window.location.href = "/React/Index";
        //}).catch ((error) => {
        //    console.log("Error", data.error);
        //    alert(data.Message)
        //})
    }
    onChange = (e) => {
        this.setState({
            [e.target.name]: e.target.value
        })
    }



    // Add/Edit Person Modal
    render() {
        return (
            <div className="modal fade" id="PersonDetailsModal" tabIndex="-1" aria-hidden="true">
                <div className="modal-dialog">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title">Add/Edit Person Info</h5>
                            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div className="modal-body">
                            <form>
                                <div className="mb-3">
                                    <label htmlFor="txtName" className="col-form-label">Name</label>
                                    {/*<input type="text" className="form-control" id="txtName" name="Name" value={this.state.Name} onChange={this.onChange} />*/}
                                </div>
                                <div className="mb-3">
                                    <label htmlFor="txtPhone" className="col-form-label">Phone</label>
                                    {/*<input type="text" className="form-control" id="txtPhone" name="Phone" value={this.state.Phone} onChange={this.onChange} />*/}
                                </div>
                                {/*<div className="mb-3">*/}
                                {/*    <label className="col-form-label">City</label>*/}
                                {/*    <select asp-for="CityId" className="form-control" asp-items="ViewBag.CityId"></select>*/}
                                {/*</div>*/}
                                <div className="mb-3">
                                    <label htmlFor="txtCity" className="col-form-label">CityId</label>
                                    <input type="number" className="form-control" id="txtCity" name="CityId" value={this.state.CityId} onChange={this.onChange} />
                                </div>
                                {/*<div className="mb-3">*/}
                                {/*    <label htmlFor="txtCountry" className="col-form-label">Country</label>*/}
                                {/*    <input type="text" className="form-control" id="txtCountry" name="Country" value={this.state.Country} onChange={this.onChange} />*/}
                                {/*</div>*/}
                                {/*<div className="mb-3">*/}
                                {/*    <label htmlFor="txtLanguage" className="col-form-label">Language</label>*/}
                                {/*    <input type="text" className="form-control" id="txtLanguage" name="Language" value={this.state.Language} onChange={this.onChange} />*/}
                                {/*</div>*/}
                            </form>
                        </div>
                        <div className="modal-footer">
                            <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                            <button type="button" className="btn btn-primary btn-block" onClick={this.onSubmitting}>Save</button>

                            {/*<input type="submit" value="Save" className="btn btn-primary btn-block" />*/}
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}





////class DetailsPerson extends React.Component {
////    constructor(props) {
////        super(props);
////        this.state = {
////            PersonId: '',
////            Name: '',
////            Phone: '',
////            CityId: '',
////            City: '',
////            Country: '',
////            Language: ''
////        }
////    }
////    onSubmit = (e) => {
////        debugger
////        e.preventDefault();
////        const data = {
////            PersonId: this.state.PersonId,
////            Name: this.state.Name,
////            Phone: this.state.Phone,
////            CityId: this.state.CityId,
////            City: this.state.City,
////            Country: this.state.Country,
////            Language: this.state.Language
////        }


////        console.log("Submitted data", this.state)
////        fetch("/React/DetailsPerson", {
////            method: "POST",
////            headers: { 'Content-Type': 'application/json', },
////            body: JSON.stringify(data.PersonId),
////        }).then(response => respopnse.json())
////            .then(data => {
////                console.log("Success", data.success);
////                alert(data.Message)
////                window.location.href = "/React/Index";
////            }).catch((error) => {
////                console.log("Error", data.error);
////                alert(data.Message)
////            })
////    }
////    onChange = (e) => {
////        this.setState({
////            [e.target.name]: e.target.value
////        })
////    }

////    //Person Detail Modal
////    render() {
////        return (
////            <div className="modal fade" id="DetailsPersonModal" tabIndex="-1" aria-hidden="true">
////                <div className="modal-dialog">
////                    <div className="modal-content">
////                        <div className="modal-header">
////                            <h5 className="modal-title">Person Details</h5>
////                            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close">
////                                <span aria-hidden="true">&times;</span>
////                            </button>
////                        </div>
////                        <div className="modal-body">
////                            <form>
////                                <div className="mb-3">
////                                    <label htmlFor="txtName" className="col-form-label">Name</label>
////                                    <input type="text" className="form-control" id="txtName" name="Name" value={this.state.Name} onChange={this.onChange} />
////                                </div>
////                                <div className="mb-3">
////                                    <label htmlFor="txtPhone" className="col-form-label">Phone</label>
////                                    <input type="text" className="form-control" id="txtPhone" name="Phone" value={this.state.Phone} onChange={this.onChange} />
////                                </div>
////                                <div className="mb-3">
////                                    <label htmlFor="txtCityId" classNCityIdol-form-label">CityICityIdel>
////                                    <input type="text" className="form-control" id="txtCityId" name="CityId" value={this.state.CityId} onChange={this.onChange} />
////                                    {/*<select asp-for="CityId" className="form-control" asp-items="ViewBag.CityId"></select>*/}
////                                </div>
////                                <div className="mb-3">
////                                    <ltxtCitymlFor="tCityty" className="col-fCitylabel">City</label>
////                                    <input type="text" className="form-control" id="txtCity" name="City" value={this.state.City} onChange={this.onChange} />
////                                    {/*<select asp-for="City" className="form-control" asp-items="ViewBag.City"></select>*/}
////                                </div>
////                                <div className="mb-3">
////                                    <label htmlFor="txtCountry" className="col-form-label">Country</label>
////                                    <input type="text" className="form-control" id="txtCountry" name="Country" value={this.state.Country} onChange={this.onChange} />
////                                </div>
////                                <div className="mb-3">
////                                    <label htmlFor="txtLanguage" className="col-form-label">Language</label>
////                                    <input type="text" className="form-control" id="txtLanguage" name="Language" value={this.state.Language} onChange={this.onChange} />
////                                </div>
////                            </form>
////                        </div>
////                        <div className="modal-footer">
////                            <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Close</button>
////                        </div>
////                    </div>
////                </div>
////            </div>
////        )
////    }
////}