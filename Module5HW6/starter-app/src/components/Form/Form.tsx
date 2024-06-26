import React, { FC, ReactElement } from "react";
import {Box, Button, Container, CssBaseline, TextField, Typography} from "@mui/material";
import { InputConfig } from "./Input/IInputConfig";

interface FormProps {
    title: string,
    inputs: InputConfig[],
    buttonText: string,
    handleSubmit: (event: React.FormEvent<HTMLFormElement>) => void;
}

const Form: FC<FormProps> = (props: FormProps): ReactElement => {
    
    const { title, inputs,buttonText, handleSubmit } = props;
    
    return (
            <Container component="main" maxWidth="xs">
                <CssBaseline />
                <Box
                    sx={{
                        marginTop: 8,
                        display: 'flex',
                        flexDirection: 'column',
                        alignItems: 'center',
                    }}
                >
                    <Typography component="h1" variant="h5">
                        {title}
                    </Typography>
                    <Box component="form" onSubmit={handleSubmit} sx={{ mt: 1 }}>
                        {inputs.map((input, i) => (
                            <TextField
                                key={i}
                                required
                                margin="normal"
                                fullWidth
                                id={input.name}
                                label={input.label}
                                name={input.name}
                                type={input.type}
                                onChange={input.onChange}
                                autoComplete={input.name}
                                autoFocus
                            />
                        ))}
                        <Button
                            type="submit"
                            fullWidth
                            variant="contained"
                            sx={{ mt: 3, mb: 2 }}
                        >
                            {buttonText}
                        </Button>
                    </Box>
                </Box>
            </Container>
    );
};

export default Form;
