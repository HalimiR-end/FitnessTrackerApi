// User types
export interface User {
  id: number;
  username: string;
  email: string;
  role: string;
  createdAt: Date;
}

export interface UserRegisterDto {
  username: string;
  email: string;
  passwordHash: string;
}

export interface LoginUserDto {
  email: string;
  passwordHash: string;
}

// Workout types
export interface WorkoutDto {
  id: number;
  name?: string;
  date: Date;
  userId: number;
  description?: string;
}

export interface CreateWorkoutDto {
  name: string;
  description?: string;
  userId: number;
}

// Workout Entry types
export interface WorkoutEntryDto {
  id: number;
  workoutId: number;
  exerciseId: number;
  sets: number;
  reps: number;
  weight: number;
}

export interface CreateWorkoutEntryDto {
  workoutId: number;
  exerciseId: number;
  sets: number;
  reps: number;
  weight: number;
}

// Exercise types
export interface ExerciseDto {
  id: number;
  name: string;
  description?: string;
  muscleGroup: string;
}

export interface CreateExerciseDto {
  name: string;
  description?: string;
  muscleGroup: string;
}

// Nutrition types
export interface NutritionLogDto {
  id: number;
  description?: string;
  calories: number;
  date: Date;
  userId: number;
}

// Measurement types
export interface MeasurementDto {
  id: number;
  date: Date;
  weight: number;
  waist: number;
  chest: number;
  biceps: number;
  userId: number;
}

// Progress Photo types
export interface ProgressPhotoDto {
  id: number;
  imageUrl?: string;
  date: Date;
  userId: number;
}

// Goal types
export interface GoalDto {
  id: number;
  description?: string;
  targetDate: Date;
  userId: number;
  isAchieved?: boolean;
}