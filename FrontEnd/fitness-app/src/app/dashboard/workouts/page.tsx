'use client';

import { useState, useEffect } from 'react';
import { WorkoutDto } from '../../lib/types';
import apiClient from '../../lib/api/client';
import { useAuth } from '../../..../../context/AuthContext';
import WorkoutCard from '../../components/ui/WorkoutCard';
import WorkoutModal from '../../components/forms/WorkoutModal';

export default function WorkoutsPage() {
  const [workouts, setWorkouts] = useState<WorkoutDto[]>([]);
  const [loading, setLoading] = useState(true);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const { user } = useAuth();

  useEffect(() => {
    const fetchWorkouts = async () => {
      try {
        const response = await apiClient.get(`/workouts/user/${user?.id}`);
        setWorkouts(response.data);
      } catch (error) {
        console.error('Failed to fetch workouts', error);
      } finally {
        setLoading(false);
      }
    };

    if (user?.id) {
      fetchWorkouts();
    }
  }, [user?.id]);

  const handleAddWorkout = async (workoutData: CreateWorkoutDto) => {
    try {
      const response = await apiClient.post('/workouts', workoutData);
      setWorkouts([...workouts, response.data]);
      setIsModalOpen(false);
    } catch (error) {
      console.error('Failed to add workout', error);
    }
  };

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <div className="space-y-6">
      <div className="flex justify-between items-center">
        <h1 className="text-2xl font-bold">Your Workouts</h1>
        <button
          onClick={() => setIsModalOpen(true)}
          className="px-4 py-2 bg-indigo-600 text-white rounded-md hover:bg-indigo-700"
        >
          Add Workout
        </button>
      </div>

      {workouts.length === 0 ? (
        <div className="text-center py-12">
          <p className="text-gray-500">No workouts yet. Add your first workout!</p>
        </div>
      ) : (
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
          {workouts.map((workout) => (
            <WorkoutCard key={workout.id} workout={workout} />
          ))}
        </div>
      )}

      <WorkoutModal
        isOpen={isModalOpen}
        onClose={() => setIsModalOpen(false)}
        onSubmit={handleAddWorkout}
        userId={user?.id || 0}
      />
    </div>
  );
}