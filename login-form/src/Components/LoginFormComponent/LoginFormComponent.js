import React from "react"
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'
import './LoginFormComponent.css'
import { Component } from "react";


class LoginFormComponent extends Component{
    constructor(props){
        super(props);
        this.state={email:'',password:''};

        this.handleSubmit=this.handleSubmit.bind(this);
        this.handleInputChange=this.handleInputChange.bind(this);
    }

    handleInputChange(event) {
        const target = event.target;
        const value = target.type === 'checkbox' ? target.checked : target.value;
        this.setState({
            [target.name]: value
        });
    }

    handleSubmit(event){
        console.log(`Submit: ${this.state.email}`);
        event.preventDefault();
    }

    render(){
        return (
            <div className="loginContainer">
                <Form onSubmit={this.handleSubmit}>
                    <Form.Group controlId="formEmail">
                        <Form.Label>Email address</Form.Label>
                        <Form.Control type="email" name="email" placeholder="Enter email" onChange={this.handleInputChange}/>
                   </Form.Group>
                    <Form.Group controlId="formPassword">
                        <Form.Label>Password</Form.Label>
                        <Form.Control type="password" name="password" placeholder="Password" onChange={this.handleInputChange}/>
                    </Form.Group>
                    <Button variant="primary" type="submit">
                        Submit
                    </Button>
                </Form>
            </div>
        );
    }
}



// function LoginFormComponent() {
    // return (
    //     <div className="loginContainer">
    //         <Form>
    //             <Form.Group controlId="formEmail">
    //                 <Form.Label>Email address</Form.Label>
    //                 <Form.Control type="email" placeholder="Enter email" />
    //            </Form.Group>
    //             <Form.Group controlId="formPassword">
    //                 <Form.Label>Password</Form.Label>
    //                 <Form.Control type="password" placeholder="Password" />
    //             </Form.Group>
    //             <Button variant="primary" type="submit">
    //                 Submit
    //             </Button>
    //         </Form>
    //     </div>
    // );
// }

export default LoginFormComponent;
