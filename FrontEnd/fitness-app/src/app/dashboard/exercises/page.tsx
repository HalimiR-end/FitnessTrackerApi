'use client';

import { useState, useEffect } from 'react';
import { ExerciseDto } from '../../lib/types';
import apiClient from '../../lib/api/client';
import ExerciseCard from '../../components/ui/ExerciseCard';
import ExerciseModal from '../../components/forms/ExerciseModal';

export default function ExercisesPage() {
  const [exercises, setExercises] = useState<ExerciseDto[]>([]);
  const [loading, setLoading] = useState(true);
  const [isModalOpen, setIsModalOpen] = useState(false);

  useEffect(() => {
    const fetchExercises = async () => {
      try {
        const response = await apiClient.get('/exercises');
        setExercises(response.data);
      } catch (error) {
        console.error('Failed to fetch exercises', error);
      } finally {
        setLoading(false);
      }
    };

    fetchExercises();
  }, []);

  const handleAddExercise = async (exerciseData: CreateExerciseDto) => {
    try {
      const response = await apiClient.post('/exercises', exerciseData);
      setExercises([...exercises, response.data]);
      setIsModalOpen(false);
    } catch (error) {
      console.error('Failed to add exercise', error);
    }
  };

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <div className="space-y-6">
      <div className="flex justify-between items-center">
        <h1 className="text-2xl font-bold">Exercises</h1>
        <button
          onClick={() => setIsModalOpen(true)}
          className="px-4 py-2 bg-indigo-600 text-white rounded-md hover:bg-indigo-700"
        >
          Add Exercise
        </button>
      </div>

      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
        {exercises.map((exercise) => (
          <ExerciseCard key={exercise.id} exercise={exercise} />
        ))}
      </div>

      <ExerciseModal
        isOpen={isModalOpen}
        onClose={() => setIsModalOpen(false)}
        onSubmit={handleAddExercise}
      />
    </div>
  );
}