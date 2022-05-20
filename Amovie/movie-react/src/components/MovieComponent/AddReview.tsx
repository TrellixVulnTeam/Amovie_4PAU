import { yupResolver } from "@hookform/resolvers/yup";
import { Box, Grid, TextField, Typography, Button } from "@mui/material";
import { useForm } from "react-hook-form";
import { Review } from "../../Types/Types";
import { addReviewSchema } from "../../validations/addReviewValidation";

export function AddReview(props: any) {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<Review>({ resolver: yupResolver(addReviewSchema) });

  const onSubmit = async (values: any) => {
    const url = "http://localhost:7063/api/addreview";
    const movieID = window.location.pathname.substring(
      window.location.pathname.lastIndexOf("/") + 1
    );
    let currentUser = localStorage.getItem("name");
    const data = {
      user: currentUser,
      content: values.content,
      movieId: movieID,
    };
    try {
      await fetch(url, {
        method: "POST",
        body: JSON.stringify(data),
        headers: {
          "Content-Type": "application/json",
        },
      });
      props.setOpen(!props.open);
    } catch (error) {
      console.error("Error:", error);
    }
  };

  return (
    <Box
      component="form"
      onSubmit={handleSubmit(onSubmit)}
      sx={{ display: "block", mt: 4, mb: 4 }}
    >
      <Grid container spacing={2} sx={{ display: "block" }}>
        <Grid item xs={6}>
          <TextField
            fullWidth
            id="Content"
            label="Review content"
            {...register("content", {})}
          />
          {errors.content && (
            <Typography style={{ color: "#F95252" }}>
              * {errors.content.message}
            </Typography>
          )}
        </Grid>
        <Button type="submit" variant="contained" sx={{ mt: 3, ml: 2 }}>
          Add review
        </Button>
      </Grid>
    </Box>
  );
}
