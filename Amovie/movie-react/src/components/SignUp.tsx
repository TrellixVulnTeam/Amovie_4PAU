import {
  Avatar,
  Box,
  Button,
  Grid,
  TextField,
  Typography,
} from "@mui/material";
import { Link } from "react-router-dom";
import { useForm } from "react-hook-form";

import Container from "@mui/material/Container";

type FormTypes = {
  name: string;
  email: string;
  password: string;
};

export default function SignUp() {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<FormTypes>();

  const onSubmit = (values:FormTypes) => {
    console.log(values);
  };

  return (
    <Container component="main" maxWidth="xs">
      <Box
        sx={{
          marginTop: 8,
          marginBottom: 8,
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
        }}
      >
        <Avatar sx={{ m: 1, bgcolor: "primary.main" }}></Avatar>
        <Typography component="h1" variant="h5" sx={{ fontWeight: "bold" }}>
          {" "}
          Sign up{" "}
        </Typography>
        <Box component="form" onSubmit={handleSubmit(onSubmit)} sx={{ mt: 3 }}>
          <Grid container spacing={2}>
            <Grid item xs={12}>
              <TextField
                fullWidth
                id="name"
                label="Name"
                autoComplete="family-name"
                {...register('name', {
                  minLength: {
                    value: 3,
                    message: "Name must containt at least 3 characters",
                  },
                  maxLength: {
                    value: 20,
                    message: "Name must contain at most 20 characters"
                  },
                  required: "Name is required"
                })}
              />
              {errors.name && <p>{errors.name.message}</p>}
            </Grid>
            <Grid item xs={12}>
              <TextField
                required
                fullWidth
                id="email"
                label="Email Address"
                autoComplete="email"
                {...register('email')}
              />
              {errors.email && <p>{errors.email.message}</p>}

            </Grid>
            <Grid item xs={12}>
              <TextField
                required
                fullWidth
                label="Password"
                type="password"
                id="password"
                autoComplete="new-password"
                {...register('password')}
              />
                {errors.password && <p>{errors.password.message}</p>}

            </Grid>
          </Grid>
          <Button
            type="submit"
            fullWidth
            variant="contained"
            sx={{ mt: 3, mb: 2 }}
          >
            {" "}
            Sign Up{" "}
          </Button>
          <Grid container justifyContent="flex-end">
            <Grid item>
              <Link to="/signin"> Already have an account? Sign in </Link>
            </Grid>
          </Grid>
        </Box>
      </Box>
    </Container>
  );
}
